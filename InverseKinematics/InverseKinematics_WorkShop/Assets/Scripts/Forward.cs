using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.forward*1f*Time.deltaTime;
    }
}
