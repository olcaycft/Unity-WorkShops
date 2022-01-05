using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.SetActive(false);
            pooledObjects.Enqueue(player);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject player = pooledObjects.Dequeue();
        player.SetActive(true);
        pooledObjects.Enqueue(player);
        return player;
    }
    
}
