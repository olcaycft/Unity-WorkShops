using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coding : MonoBehaviour
{
    int num = 0;
    bool oyunbasladi = false;
    // Start is called before the first frame update
    void Start()
    {
        //Sadece uygulama ilk açýlýrken
        if (oyunbasladi != true)
        {
            Debug.Log("Selam");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //bütün framlerde yani 30 frame varsa her frame de bu çalýþacak.
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(Selam(num));
            num++;
        }
    }
    public int Selam(int num)
    {
        return num;
    }
}
