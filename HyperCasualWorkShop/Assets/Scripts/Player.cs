using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float sideMovementSensitivity = 1f;

    private Vector2 inputDrag;

    private Vector2 previousMousePosition;

    private float leftLimitX => leftLimit.localPosition.x;
    private float rightLimitX => rightLimit.localPosition.x;
    void Update()
    {
        ForwardMovement();
        HandleInput();
        SideMovement();
    }

    private void ForwardMovement()
    {
        //transform.position += Vector3.forward * Time.deltaTime *speed;
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void SideMovement()
    {
        var lovalPos = sideMovementRoot.localPosition;
        lovalPos += Vector3.right * inputDrag.x * sideMovementSensitivity;
        lovalPos.x = Mathf.Clamp(lovalPos.x,leftLimitX,rightLimitX);
        sideMovementRoot.localPosition = lovalPos;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var deltaMouse = (Vector2)Input.mousePosition - previousMousePosition;
            inputDrag = deltaMouse;
            previousMousePosition = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }
}
