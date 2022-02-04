using System;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private Vector3 startPoint;
    private int planeCount = 10;

    private void Awake()
    {
        GeneratePlane();
    }

    private void GeneratePlane()
    {
        for (int i = 0; i <planeCount ; i++)
        {
            GameObject plane=Instantiate(planePrefab, startPoint, Quaternion.identity);
            startPoint = plane.transform.GetChild(1).transform.position;
        }
    }
}
