using System;
using UnityEngine;

public class DestinationTracker : MonoBehaviour
{
    private Vector3 enemyPosition;

    private void Awake()
    {
        enemyPosition = GameManager.Instance.GetDestination();
    }

    private void Update()
    {
        TrackDestination();
    }

    private void TrackDestination()
    {
        var pos = transform.position;
        transform.position = Vector3.MoveTowards(pos,
            Vector3.Lerp(pos, enemyPosition, 3f), 3f * Time.deltaTime);
        if (Vector3.Distance(pos, enemyPosition) < 0.001f)
        {
            Destroy(gameObject);
        }
    }
}