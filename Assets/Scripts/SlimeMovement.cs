using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SlimeMovement : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float speed = 3f;
    public Rigidbody2D rb;
    private Animator animator;
    private bool movingToEndPoint = true;


    private bool isJump = true;
    public float jumpForce = 10f;
    public float jumpdelay = 2f;
    private float time = 0f;

    public float groundCheckDistant = 0.2f;
    public LayerMask groundLayer;
    public Vector2 boxsize;
    public float offsetX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {   
        
        if (isGrounded())
        {
            
            time += Time.deltaTime;
            if (time >= jumpdelay) { 
                isJump = true;
            }
        }

        StartPoint.position = new Vector3(StartPoint.position.x, transform.position.y, StartPoint.position.z);
        EndPoint.position = new Vector3(EndPoint.position.x, transform.position.y, EndPoint.position.z);
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
        if (!isJump) return;
        Vector3 direction= new Vector3();
        float x = targetPosition.x - transform.position.x;
        direction.x =x;
        rb.velocity = direction.normalized * speed;
        jump();
        
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        time = 0f;
        isJump = false;
    }

    bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position + new Vector3(offsetX, 0, 0), boxsize, 0, -transform.up, groundCheckDistant, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(offsetX, 0, 0) - transform.up * groundCheckDistant, boxsize);
    }


}
