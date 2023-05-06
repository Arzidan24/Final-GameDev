using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth;
    int currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        if (currenthealth <= 0) {
             Destroy(gameObject, 0f);
        }
    }*/
}
