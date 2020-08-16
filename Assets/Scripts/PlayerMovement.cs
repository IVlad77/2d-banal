using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool isGrounded = false;
    public float jumpHeight;

    private float inputX;

    private Animator anim;

    

    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        
        Vector3 moveInput = new Vector3(inputX * speed, 0.0f, 0.0f);
        moveInput *= Time.deltaTime;
        
        transform.Translate(moveInput);

        Jump();

        if(inputX == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        
    }

    private void FixedUpdate()
    {
       


    }


   
   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("isJumping", true);
            rb.velocity += jumpHeight * Vector2.up;
        }
        else
        {
            anim.SetBool("isJumping", false);

        }    
    }

}