using System;
using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private ObjectPool objectPool;

    private void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }


    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var player = objectPool.GetPooledObject();

            player.transform.position = Vector3.zero;
            
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}