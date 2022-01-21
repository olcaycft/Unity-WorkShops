using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Rigidbody2D _rb;
    private Rigidbody2D rb=>_rb=GetComponent<Rigidbody2D>();
    
    private Collider2D _collider;
    private Collider2D collider=>_collider=GetComponent<Collider2D>();

    private Collider2D[] results;

    private float moveInput;
    private float jumpForce=5f;

    private bool facingRight = true;
    private bool isGrounded;
    private Vector2 direction;
    private void Awake()
    {
        results = new Collider2D[4];
    }

    void FixedUpdate()
    {
        //HandleInput();
        rb.MovePosition(rb.position+direction*Time.deltaTime);
    }

    private void Update()
    {
        HandleInput();
        CollisionChecker();
    }

    private void CollisionChecker()
    {
        isGrounded = false;
        Vector2 size = collider.bounds.size;
        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);
        for (int i = 0; i < amount; i++)
        {
            GameObject hit = results[i].gameObject;
            if (hit.layer.Equals(LayerMask.NameToLayer("Ground")))
            {
                isGrounded=(hit.transform.position.y<(this.transform.position.y-0.5f));
            }
        }
    }
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        direction.x = moveInput * movementSpeed;
        //rb.velocity = new Vector2(moveInput * movementSpeed,rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb.velocity = Vector2.up * jumpForce;
            direction = Vector2.up * jumpForce;
        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }

        if (isGrounded)
        {
            direction.y = Math.Max(direction.y, -1f);
        }
        
        if (direction.x>0f)//(!facingRight && moveInput>0)
        {
            transform.eulerAngles = Vector3.zero;
            //Flip();
        }
        else if(direction.x<0f)//(facingRight && moveInput<0)
        {
            transform.eulerAngles=new Vector3(0f,180f,0f);
            //Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}