using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPatrol : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float speed = 3f;
    public Rigidbody2D rb;
    private Animator animator;
    private bool movingToEndPoint = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (movingToEndPoint)
        {
            MoveTowards(EndPoint.position);
            if (Vector3.Distance(transform.position, EndPoint.position) < 0.5f)
            {
                movingToEndPoint = false;
                Flip();
            }
        }
        else
        {
            MoveTowards(StartPoint.position);
            if (Vector3.Distance(transform.position, StartPoint.position) < 0.5f)
            {
                movingToEndPoint = true;
                Flip();
            }
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        rb.velocity = direction * speed;
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
