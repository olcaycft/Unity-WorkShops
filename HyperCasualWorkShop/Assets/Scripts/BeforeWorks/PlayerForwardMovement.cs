using System;
using UnityEngine;
using UnityEngine.Video;

public class PlayerForwardMovement : MonoBehaviour
{
    [SerializeField]private float speed = 12f;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime*speed;
    }

    private void SpeedChanger()
    {
        speed = 6f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Push"))
        {
            Invoke(nameof(SpeedChanger),0.5f);
        }
        else if (other.gameObject.CompareTag("Destination"))
        {
            gameObject.SetActive(false);
        }
        
    }
}
