using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float initialForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 force = new Vector2(xDirection, yDirection) * initialForce;

        rb.velocity = force;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // «упин€Їмо м'€ч.
            rb.velocity = Vector2.zero;

            // ƒодаЇмо власноруч силу вручну дл€ в≥дбитт€ м'€ча в≥д гравц€.
            Vector2 force = new Vector2(0f, initialForce);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
