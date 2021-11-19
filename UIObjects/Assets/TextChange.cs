using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Text sahnedekitext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButonIslemler()
    {
        sahnedekitext.text = "Merhaba";
    }
}
