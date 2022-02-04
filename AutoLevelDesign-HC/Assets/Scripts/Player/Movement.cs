using System;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform playerSideMovementRoot;
        [SerializeField] private Transform playerLeftLimit;
        [SerializeField] private Transform playerRightLimit;
        private float boyLeftLimitX => playerLeftLimit.localPosition.x;
        private float boyRightLimitX => playerRightLimit.localPosition.x;

        private Vector2 inputDrag;
        private Vector2 previousMousePosition;

        private float speed = 3f;
        [SerializeField]private float sideMovementSensitivity = 0.5f;

        private void FixedUpdate()
        {
            HandleInput();
            ForwardMovement();
            SideMovement();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                var deltaMouse = (Vector2) Input.mousePosition - previousMousePosition;
                inputDrag = deltaMouse;
                previousMousePosition = Input.mousePosition;
            }
            else
            {
                inputDrag = Vector2.zero;
            }
        }

        private void ForwardMovement()
        {
            player.transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        private void SideMovement()
        {
            var localPosBoy = playerSideMovementRoot.localPosition;
            localPosBoy += Vector3.right * inputDrag.x * sideMovementSensitivity;
            localPosBoy.x = Mathf.Clamp(localPosBoy.x, boyLeftLimitX, boyRightLimitX);
            playerSideMovementRoot.localPosition = localPosBoy;
        }
    }
}