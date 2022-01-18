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
        Vector3 destinationDirection = enemyPosition - transform.position;
        float singleStep = 3f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, destinationDirection, singleStep, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        var pos = transform.position;
        transform.position = Vector3.MoveTowards(pos,
            Vector3.Lerp(pos, enemyPosition, 3f), 3f * Time.deltaTime);
        if (Vector3.Distance(pos, enemyPosition) < 0.001f)
        {
            Destroy(gameObject);
        }
    }
}