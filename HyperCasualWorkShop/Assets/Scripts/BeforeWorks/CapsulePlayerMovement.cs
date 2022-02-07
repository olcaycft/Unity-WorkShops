using System;
using UnityEngine;

namespace CapsulePlayer
{
    public class CapsulePlayerMovement : MonoBehaviour
    {
        private float speed = 5f;
        private void Update()
        {
            ForwardMovement();
        }

        private void ForwardMovement()
        {
            transform.position+=Vector3.forward*Time.deltaTime*speed;
        }
    }
}

