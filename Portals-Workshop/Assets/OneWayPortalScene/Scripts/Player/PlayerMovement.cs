using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private void Update()
    {
        PlayerMovementController();
    }

    private void PlayerMovementController()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
    }
}