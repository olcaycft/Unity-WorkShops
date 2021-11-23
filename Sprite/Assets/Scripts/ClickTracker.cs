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
    private void OnMouseDrag()
    {
        Vector2 pos = Input.mousePosition; //2 boyutlu vektorde farenýn pozisyonunu pos a atadýk.
        Vector3 objPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x,pos.y,1f));
        //ekranda bulunan noktayý sahneye uyarlamak için 3 boyutlu cunku býzým ortamýmýz. ekrandaki noktaya objeyi eklemek için

        transform.position = objPos; //fare týklanýp sürüklendikçe farenin pozisyonu dogrultusunda ekrana obj nin pos unu transformlýyoruz.
    }
}
