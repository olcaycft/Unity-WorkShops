using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    //fare t�klan�ld��� zaman bu kullan�l�r
    private void OnMouseDown()
    {
        text.text = this.name;
    }
}
