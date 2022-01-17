using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject missilePrefab;

    private void Update()
    {
        InputHandle();
    }

    private void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missilePrefab, shootingPoint.position, shootingPoint.rotation);
        }
    }
   
            
}
