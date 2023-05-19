using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliteControlCopy : MonoBehaviour
{
    public GameObject leftpoint, rightpoint; // points for patroling
    public int maxhealth;
    public int currenthealth;
    public float speed;
    public float switchDistance;
    public float detectionDistance = 10f; // added detection distance
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    private bool switched = false;
    private Transform playerTransform; // added player transform
    public LayerMask playerLayers;
    [SerializeField] Transform attackpoint;
    public float attackrange = 5f;
    public int attackdamage = 10;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Canvas canvas;

    public GameObject swordPrefab;
    public Transform swordPos;
    private GameObject player;
    private float timer;
    public GameObject parent;
    public AudioSource throwSword;
    public static AudioSource swordHit;
    public AudioSource death;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = rightpoint.transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // added player transform
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
        fill.color =  gradient.Evaluate(1f);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position); // gets player distance
        
        Vector2 direction = currentpoint.position - transform.position;
        float distanceToPlayer = Mathf.Abs(playerTransform.position.x - transform.position.x);

        if (distanceToPlayer < detectionDistance) // if player is whithin te enemy detection distance
    {
        // face player
        if (playerTransform.position.x > transform.position.x) // depending on where the player is roates to face the player
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        // if within attack range, play attack animation
        if(distanceToPlayer <= 15f){
            timer += Time.deltaTime;
            if(timer > 3) // added timer so that it doesnt spam attack
            {
            timer = 0;
            anim.SetTrigger("Attack");
            throwSword.Play();
            }
        }
        // otherwise, move towards player
        else
        {
            if (playerTransform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    } else // continue walking animation */
        {
        //anim.SetBool("idle", false);
        if(direction.x > 0)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        } else {
            rb.velocity = new Vector2(-speed, 0);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(direction.magnitude < switchDistance && currentpoint == rightpoint.transform && !switched) //switchs if it reaches the points
        {
            switched = true;
            currentpoint = leftpoint.transform;
        }
        if(direction.magnitude < switchDistance && currentpoint == leftpoint.transform && !switched) //switchs if it reaches the points
        {
            switched = true;
            currentpoint = rightpoint.transform;
        }
        if(direction.magnitude > switchDistance)
        {
            switched = false;
        }
        }
    }
    public void takedamage(int damage) { // when the player attacks, the player takes and uses this function to deal damage to the enemy
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        Sethealth();
        if (currenthealth <= 0) { // destroys the enemy, and the canvas displaying its health
             Destroy(gameObject, 0f);
             Destroy(canvas, 0f);
             Destroy(parent, 0f);
             death.Play();
        }
    }
    public void attack() { // called in the attack animation, takes the players EnemyInteraction component and uses the takdmage function to the deal damage
       Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, playerLayers);

       foreach(Collider2D enemy in hitenemies)
       {
        if(enemy.GetComponent<EnemyInteraction>()){
        swordHit.Play();
        enemy.GetComponent<EnemyInteraction>().takedamage(attackdamage);
        }
       }
    }
    public void Sethealth() { // updates the slider health to the current elite enemy health
        slider.value = currenthealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void shoot() { // shoots the sword towards the player, sword logic is coded in EliteSwordscript
        Instantiate(swordPrefab, swordPos.position, Quaternion.identity);
    }

     void OnDrawGizmosSelected() { // debug visual spehere for attack range 
        if (attackpoint == null) 
            return;

       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
