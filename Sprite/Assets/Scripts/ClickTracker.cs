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
    private void OnMouseDrag()
    {
        Vector2 pos = Input.mousePosition; //2 boyutlu vektorde faren�n pozisyonunu pos a atad�k.
        Vector3 objPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x,pos.y,1f));
        //ekranda bulunan noktay� sahneye uyarlamak i�in 3 boyutlu cunku b�z�m ortam�m�z. ekrandaki noktaya objeyi eklemek i�in

        transform.position = objPos; //fare t�klan�p s�r�klendik�e farenin pozisyonu dogrultusunda ekrana obj nin pos unu transforml�yoruz.
    }
}
