using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
}