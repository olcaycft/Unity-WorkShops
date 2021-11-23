using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    //fare týklanýldýðý zaman bu kullanýlýr
    private void OnMouseDown()
    {
        text.text = this.name;
    }
}
