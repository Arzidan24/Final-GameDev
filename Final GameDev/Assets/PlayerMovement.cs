using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private bool isJumping = false;
   private Animator anim;
   private BoxCollider2D coll;
   [SerializeField] private float movespeed = 4f;
   [SerializeField] private float sprintspeed = 12f;
   [SerializeField] private float jumpforce = 14f;
   [SerializeField] LayerMask jumpableGround;

   [SerializeField] Transform attackpoint;
   [SerializeField] private AudioSource walkSound;

   public LayerMask enemyLayers;

   public float attackrange = 0.5f;
   public int attackdamage = 10;
   public AudioSource punch;
   public AudioSource walk;
    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
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

       if (Input.GetButtonDown("Jump") && Isgrounded())
      {
         rb.velocity = new Vector2(rb.velocity.x, jumpforce);
         isJumping = true;
         rb.freezeRotation = true;
         anim.SetBool("jump", true);
      }
      if (Input.GetButtonDown("Fire1")) {
        punch.Play();
        anim.SetTrigger("attack");
        attack();
      }
       if (isJumping == false)
        {
            anim.SetBool("jump", false);
        }
       if (dirX > 0f)
        {
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            if (isJumping == false)
        {
            walkSound.Play();
        }
        }
       if (dirX < 0f)
        {
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
       if (dirX == 0f)
        {
            walk.Play();
            anim.SetBool("walk", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
{
    if ((jumpableGround & (1 << collision.gameObject.layer)) != 0) // check if the collided object is on the Ground layer
    {
        isJumping = false;
    }
}
   public void SetAttackBoolToFalse()
    {
        anim.SetBool("attack", false);
    }

    private bool Isgrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void attack() {
       Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

       foreach(Collider2D enemy in hitenemies)
       {
        if(enemy.GetComponent<GruntControl>()){
        enemy.GetComponent<GruntControl>().takedamage(attackdamage);
        }
        else{
            enemy.GetComponent<EliteControl>().takedamage(attackdamage);
        }
       }
    }

    void OnDrawGizmosSelected() {
        if (attackpoint == null) 
            return;

       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}