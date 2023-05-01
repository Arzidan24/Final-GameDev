using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private bool isJumping = false;
   private Animator anim;
   [SerializeField] private float movespeed = 4f;
   [SerializeField] private float sprintspeed = 16f;
   [SerializeField] private float jumpforce = 14f;

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
      bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

      if (isSprinting)
      {
         rb.velocity = new Vector2(dirX * sprintspeed, rb.velocity.y);
      }
      else
      {
         rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
      }
      /*rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);*/

       if (Input.GetButtonDown("Jump") && !isJumping)
      {
         rb.velocity = new Vector2(rb.velocity.x, jumpforce);
         isJumping = true;
         rb.freezeRotation = true;
         anim.SetBool("jump", true);
      }
      if (Input.GetButtonDown("Fire1")) {
        anim.SetBool("attack", true);
      }
       if (isJumping == false)
        {
            anim.SetBool("jump", false);
        }
       if (dirX > 0f)
        {
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
       if (dirX < 0f)
        {
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
   public void SetAttackBoolToFalse()
    {
        anim.SetBool("attack", false);
    }
}