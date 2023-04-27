using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private bool isJumping = false;
   private Animator anim;

    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   private void Update()
    {
      float dirX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);

       if (Input.GetButtonDown("Jump") && !isJumping)
      {
         rb.velocity = new Vector2(rb.velocity.x, 14f);
         isJumping = true;
         rb.freezeRotation = true;
         anim.SetBool("jump", true);
      }
       if (isJumping == false)
        {
            anim.SetBool("jump", false);
        }
       if (dirX > 0f)
        {
            anim.SetBool("walk", true);
        }
       if (dirX < 0f)
        {
            anim.SetBool("walk", true);
        }
       if (dirX == 0f)
        {
            anim.SetBool("walk", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         isJumping = false;
      }
   }
}