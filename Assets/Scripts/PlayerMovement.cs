using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpforce = 5;
    Rigidbody2D rigitbody;
    float moveDir;
    public float dashTime=1f;
    public float dashSpeed = 15f;
   

    public float groundCheckDistant = 0.2f;
    public LayerMask groundLayer;
    public Vector2 boxsize;
    public float offsetX;

    Animator animator;
    private String CurrentAnimationState;

    private bool isWalk =false;
    private bool isjump = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigitbody = GetComponent<Rigidbody2D>();
        ChangeAnimationState("Idle");
    }
    
    // Update is called once per frame
    void Update()
    {
        moveDir = Input.GetAxis("Horizontal");
        if (moveDir != 0)
        {
            isWalk = true;

        }
        else
        {
            isWalk = false;
        }

        if (moveDir > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        else if (moveDir < 0 && transform.localScale.x > 0)
        {
            Flip();
        }


        rigitbody.velocity = new Vector2(moveDir * speed, rigitbody.velocity.y);
        
        if (Input.GetKeyDown("space")&&isGrounded())
        {
            rigitbody.velocity = new Vector2(rigitbody.velocity.x,jumpforce);
        }

        if (!isGrounded())
        {
            isjump = true;
        }
        else
        {
            isjump = false;
        }

        if (isjump)
        {
            ChangeAnimationState("Jump");
        }
        else if(isWalk){
            ChangeAnimationState("Walk");
        }
        else
        {
            ChangeAnimationState("Idle");
        }



    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position + new Vector3(offsetX, 0, 0), boxsize, 0, -transform.up, groundCheckDistant, groundLayer))
        {
            return true;
        }else{
            return false; 
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(offsetX, 0, 0) - transform.up * groundCheckDistant, boxsize);
    }

    private void ChangeAnimationState(String newState)
    {
        if(CurrentAnimationState == newState) return;
        animator.Play(newState);
        CurrentAnimationState = newState;
    }
}
