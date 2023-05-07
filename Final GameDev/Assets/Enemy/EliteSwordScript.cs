using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteSwordScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        if(direction.x > 0){
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 180);
        } else {
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.CompareTag("Player")){
        other.gameObject.GetComponent<EnemyInteraction>().takedamage(damage);
        Destroy(gameObject);
        EliteControl.swordHit.Play();
       } 
    }
}
