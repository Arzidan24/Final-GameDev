using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntControl : MonoBehaviour
{
    public GameObject leftpoint, rightpoint;
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
        currentpoint = rightpoint.transform;
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
        Debug.Log(currentpoint == rightpoint.transform);
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






