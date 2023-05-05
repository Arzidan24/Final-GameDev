using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntControl : MonoBehaviour
{
    public GameObject leftpoint, rightpoint;

    public int maxhealth = 20;

    int currenthealth;
    public float speed;
    public float switchDistance;
    public float detectionDistance = 5f; // added detection distance
    public GameObject knifePrefab; // added knife prefab
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    private bool switched = false;
    private Transform playerTransform; // added player transform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = rightpoint.transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // added player transform
        currenthealth = maxhealth;
    }
    //Update is called once per frame
    void Update()
    {
        Vector2 direction = currentpoint.position - transform.position;
        // dibawah lagi diperbaiki, serang player paka weapon
        /*if (Mathf.Abs(playerTransform.position.x - transform.position.x) < detectionDistance) // added player detection check
        {
            // stop animation
            anim.SetBool("idle", true);

            // face player
            if (playerTransform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            // throw knife
            GameObject knife = Instantiate(knifePrefab, transform.position - 2f * (playerTransform.position - transform.position).normalized, Quaternion.identity);
            knife.tag = "Weapon";
            knife.GetComponent<Collider2D>().isTrigger = true;
            Vector2 knifeDirection = playerTransform.position - transform.position;
            knife.GetComponent<Rigidbody2D>().velocity = knifeDirection.normalized * 10f;
            
            // destroy knife if it hits player or ground
            Destroy(knife, 5f);
        }
        else // continue walking animation */
        //{
        anim.SetBool("idle", false);
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
        //}
    }
    public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        if (currenthealth <= 0) {
             Destroy(gameObject, 0f);
        }
    }
}





