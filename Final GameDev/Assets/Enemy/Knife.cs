using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player") || (1 << collision.gameObject.layer & LayerMask.GetMask("Ground")) != 0)
{
    Destroy(gameObject);
}
}
}
