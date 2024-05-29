using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isAi;
    [SerializeField] private Transform ball;

    private Rigidbody2D rb;
    

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isAi == true)
        {
            AiPaddle();
        }
        else
        {
            rb.velocity = Vector2.up * speed * Input.GetAxis("Vertical");
        }
    }


    private void AiPaddle()
    {
        if (ball.position.y > transform.position.y + 1f && ball.position.x > 0)
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (ball.position.y < transform.position.y - 1f && ball.position.x > 0)
        {
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
