using UnityEngine;

public class BoyPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            FindObjectOfType<GameManager>().IncreaseMoney();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("RingGate"))
        {
            FindObjectOfType<GameManager>().DecreaseRingAmount();
        }
    }
}
