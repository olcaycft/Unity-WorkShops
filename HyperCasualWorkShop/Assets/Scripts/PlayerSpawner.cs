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

            player.transform.position = transform.position;
            
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}