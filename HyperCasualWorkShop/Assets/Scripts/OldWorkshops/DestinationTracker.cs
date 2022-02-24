using System;
using UnityEngine;

public class DestinationTracker : MonoBehaviour
{
    [SerializeField] private GameObject destiny;
    [SerializeField] private bool isPlayerAtNavMesh = false;
    
    private float speed=1f;

    private void Awake()
    {
        destiny = GameObject.Find("Destination");
    }

    private void Update()
    {
        if (isPlayerAtNavMesh)
        {
            DestinyChecker();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NavMeshArea"))
        {
            isPlayerAtNavMesh = true;

        }
    }


    private void DestinyChecker()
    {
        Vector3 destinyDirection = destiny.transform.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, destinyDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
