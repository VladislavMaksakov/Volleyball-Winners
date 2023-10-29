using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10f;
    public float NormalSpeed;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        Speed = 0f;
    }

    void Update()
    {
        // Ïðûæîê.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void Left()
    {
        if(Speed >= 0f)
        {
            Speed = -NormalSpeed;
        }
    }
    public void Right()
    {
        if (Speed <= 0f)
        {
            Speed = NormalSpeed;
        }
    }
    public void Idle()
    {
        Speed = 0f;
    }
}
