using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyInteraction : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private TMP_Text HealthText;
    private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Enemy"))
    {
        health = health - 2;
        HealthText.text = "Health: " + health;
    }
    if (collison.gameObject.CompareTag("Weapon"))
    {
        health = health - 2;
        HealthText.text = "Health: " + health;
    }
}
}
