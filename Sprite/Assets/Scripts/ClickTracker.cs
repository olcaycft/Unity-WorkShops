using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    //fare tıklanıldığı zaman bu kullanılır
    private void OnMouseDown()
    {
        text.text = this.name;
    }
}
