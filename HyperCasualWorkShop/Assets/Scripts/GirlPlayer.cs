using UnityEngine;

public class GirlPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            FindObjectOfType<GameManager>().IncreaseMoney();
            Destroy(col.gameObject);
        }
    }
}
