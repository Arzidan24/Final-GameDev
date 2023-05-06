using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public int health = 100;
    public int currenthealth;
    public Image fill;

    private void Start() {
        currenthealth = health;
        slider.value = currenthealth;
       fill.color =  gradient.Evaluate(1f);
    }
    [SerializeField] private TMP_Text HealthText;
    private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Enemy"))
    {
        currenthealth = currenthealth - 2;
        HealthText.text = "Health: " + currenthealth;
    }
    else if(collison.gameObject.CompareTag("Weapon"))
    {
        currenthealth = currenthealth - 2;
        HealthText.text = "Health: " + currenthealth;
    } else if (collison.gameObject.CompareTag("HealthPotion")){
        currenthealth = currenthealth + 15;
        if(currenthealth > 100) {
            currenthealth = 100;
        }
        Sethealth();
        Destroy(collison.gameObject, 0f);
    }

}
    public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        HealthText.text = "Health: " + currenthealth;
        Sethealth();
        if (currenthealth <= 0) {
             Destroy(gameObject, 0f);
        }
    }
    public void Sethealth() {
        slider.value = currenthealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
