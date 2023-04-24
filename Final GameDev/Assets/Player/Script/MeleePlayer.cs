using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlayer : MonoBehaviour

{
    private float timeBtwAtk;
    public float startTimeBtwAtk;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAtk <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length, i++)
                {
                //give dmg to enemy
                }
            }
        }
    }
}
