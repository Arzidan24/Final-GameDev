using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyInteraction : MonoBehaviour
{
    public int health = 100;
    public int currenthealth;

    private void Start() {
        currenthealth = health;
    }
    [SerializeField] private TMP_Text HealthText;
    private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Enemy"))
    {
        currenthealth = currenthealth - 2;
        HealthText.text = "Health: " + currenthealth;
    }
    if (collison.gameObject.CompareTag("Weapon"))
    {
        currenthealth = currenthealth - 2;
        HealthText.text = "Health: " + currenthealth;
    }
}
    public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        HealthText.text = "Health: " + currenthealth;
        if (currenthealth <= 0) {
             Destroy(gameObject, 0f);
        }
    }
}
