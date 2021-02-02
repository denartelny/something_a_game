using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    public float speed;
    [Header("Jump")]
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool fasingRight = true;
    private bool isGrounded;
    public float checkRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;
    private Animator anim;
  
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
      

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");

        }
        
        if(moveInput > 0)
        {
            anim.SetBool("isRunning", true);
        }else if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        if (moveInput < 0)
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void FixedUpdate()

    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("fight");
            

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(fasingRight == false && moveInput < 0)
        {
            Flip();
        }
        else if(fasingRight == true && moveInput > 0)
        {
            Flip();
        }

    }
   
    void Flip()
    {
        fasingRight = !fasingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            rb.gravityScale = 0.1f;
        }
       
    }
    private void OnTriggerExit2D(Collider2D other2)
    {
        if (other2.gameObject.tag == "Water")
        {
            rb.gravityScale = 1f;
        }
    }
   
}
