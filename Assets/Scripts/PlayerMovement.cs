using System;
using System.Collections;
using System.Collections.Generic;
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

  
    void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {

  
        moveDir = Input.GetAxis("Horizontal");
     
        rigitbody.velocity = new Vector2(moveDir * speed, rigitbody.velocity.y);
        
        if (Input.GetKeyDown("space")&&isGrounded())
        {
  
            rigitbody.velocity = new Vector2(rigitbody.velocity.x,jumpforce);
        }


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

 
}
