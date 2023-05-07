using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GruntControl : MonoBehaviour
{
    public GameObject leftpoint, rightpoint;
    public int maxhealth;
    public int currenthealth;
    public float speed;
    public float switchDistance;
    public float detectionDistance = 5f; // added detection distance
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    private bool switched = false;
    private Transform playerTransform; // added player transform
    public LayerMask playerLayers;
    [SerializeField] Transform attackpoint;
    public float attackrange = 1.5f;
    public int attackdamage = 10;
    public GameObject parent;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public Canvas canvas;

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
    }
    //Update is called once per frame
    void Update()
    {
        Vector2 direction = currentpoint.position - transform.position;
    float distanceToPlayer = Mathf.Abs(playerTransform.position.x - transform.position.x);

    if (distanceToPlayer < detectionDistance)
    {
        // face player
        if (playerTransform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        // if within attack range, play attack animation
        if (distanceToPlayer <= 1.5f)
        {
            rb.velocity = Vector2.zero;
            anim.SetTrigger("attack");
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
    }
        else // continue walking animation */
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
        if(direction.magnitude < switchDistance && currentpoint == rightpoint.transform && !switched)
        {
            switched = true;
            currentpoint = leftpoint.transform;
        }
        if(direction.magnitude < switchDistance && currentpoint == leftpoint.transform && !switched)
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
    public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        Sethealth();
        if (currenthealth <= 0) {
            Destroy(gameObject);
            Destroy(canvas, 0f);
            Destroy(parent, 0f);
        }
    }

    public void attack() {
       Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, playerLayers);

       foreach(Collider2D enemy in hitenemies)
       {
        if(enemy.GetComponent<EnemyInteraction>()){
        enemy.GetComponent<EnemyInteraction>().takedamage(attackdamage);
        }
       }
    }
    public void Sethealth() {
        slider.value = currenthealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void OnDrawGizmosSelected() {
        if (attackpoint == null) 
            return;

       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}





