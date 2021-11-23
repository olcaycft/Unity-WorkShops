using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabs : MonoBehaviour
{
    public GameObject firstkenprefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0,0,0);
        Quaternion quaternion = new Quaternion(0,0,0,0);
        Instantiate(firstkenprefab, pos, quaternion); //vector3 ile konum ve quaternion ile döngüsel deðerleri.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
