using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyInteraction : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public int health = 100;
    public int currenthealth;
    public Image fill;
    public AudioSource gameOver;
    public AudioSource potion;

    public float minY = -95;
    private bool isGameOver = false;
    [SerializeField] private TMP_Text gameOverText;

    private void Start() {
        currenthealth = health;
        slider.value = currenthealth;
       fill.color =  gradient.Evaluate(1f);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            gameOverText.text = "";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (health <= 0f || transform.position.y < minY)
        {
            gameOverText.text = "Game Over! Press 'R' to restart!";
            Time.timeScale = 0f;
            isGameOver = true;
        }
        if (isGameOver){
            gameOver.Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Enemy"))
    {
        currenthealth = currenthealth - 2;
    }
    else if(collison.gameObject.CompareTag("Weapon"))
    {
        currenthealth = currenthealth - 2;
    } else if (collison.gameObject.CompareTag("HealthPotion")){
        currenthealth = currenthealth + 15;
        if(currenthealth > 100) {
            currenthealth = 100;
        }
        Sethealth();
        potion.Play();
        Destroy(collison.gameObject, 0f);
    }

}
    public void takedamage(int damage) {
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        Sethealth();
        if (currenthealth <= 0) {
            gameOverText.text = "Game Over! Press 'R' to restart!";
            Destroy(gameObject, 0f);
            isGameOver = true;
        }
    }
    public void Sethealth() {
        slider.value = currenthealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
