using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    Rigidbody2D player;
    bool isGrounded = true;
    public float jumpforce;
    
    public float speed;
    float horizontalmovement;
    Animator anim;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalmovement = Input.GetAxisRaw("Horizontal");
        
        if (isGrounded)
        {      
            anim.SetFloat("animhiz", Mathf.Abs(horizontalmovement));
            
        }
        
        player.velocity = new Vector2(horizontalmovement * speed, player.velocity.y);

        if (Input.GetKey(KeyCode.LeftControl)&&isGrounded)
        {
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
        }
            
        



        if (horizontalmovement > 0)
        {
            transform.localScale = new Vector2(7, 7);
            
        }
       

        if (horizontalmovement < 0)
        {
            transform.localScale = new Vector2(-7, 7);
            
        }
       
        

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x,jumpforce);
            anim.SetBool("jumping", true);
            isGrounded = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("jumping", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            isGrounded = true;
        }
    }

}
