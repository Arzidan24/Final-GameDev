using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntControl : MonoBehaviour
{
    public GameObject pointA, pointB;
    public float speed;
    public float switchDistance;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    private bool switched = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = currentpoint.position - transform.position;
        if(direction.x > 0)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        } else {
            rb.velocity = new Vector2(-speed, 0);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        Debug.Log(direction.magnitude);
        Debug.Log(currentpoint == pointB.transform);
        if(direction.magnitude < switchDistance && currentpoint == pointB.transform && !switched)
        {
            switched = true;
            currentpoint = pointA.transform;
        }
        if(direction.magnitude < switchDistance && currentpoint == pointA.transform && !switched)
        {
            switched = true;
            currentpoint = pointB.transform;
        }
        if(direction.magnitude > switchDistance)
        {
            switched = false;
        }
    }
}






