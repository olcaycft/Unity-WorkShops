using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private List<Transform> path;
    private Vector3 prevPathPoint;
    public Vector3[] PathPoints => path.Select(o => o.position).ToArray();
    [SerializeField] private float speed = 10f;
    private void Start()
    {
        transform.DOPath(PathPoints, speed, PathType.CatmullRom)
            .OnUpdate(OnPathUpdate)
            .SetSpeedBased()
            .SetEase(Ease.Linear);
    }
    
    private void OnPathUpdate()
    {
        var direction = (transform.position - prevPathPoint).normalized;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        prevPathPoint = transform.position;
    }
}
