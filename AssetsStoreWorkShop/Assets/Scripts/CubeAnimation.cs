using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    Vector3 pos;
    Quaternion quat;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        quat = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pos = new Vector3(pos.x, pos.y, pos.z - 2f);
            quat = Quaternion.Euler(0, 180, 0);
        }
        transform.position = Vector3.Lerp(transform.position,pos,0.1f); //Lerp yer deðiþtirme iþlemi yapar. bulundugu yer,gideceði yer, zaman
        transform.rotation = Quaternion.Lerp(transform.rotation,quat,0.1f);
    }
}
