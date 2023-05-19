using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script handles the PLayer Interaction with the objects, enemies and displays health 
public class EnemyInteractionCopy : MonoBehaviour
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

    private void Start() { // sets health and the health bar slider
        currenthealth = health;
        slider.value = currenthealth;
       fill.color =  gradient.Evaluate(1f);
    }

    void Update() // unused game over text if the player reaches 0 HP, this code has been moved to the cameerafollowplayer script because the camera does not get destroyed, unlike the player
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
    
    private void OnTriggerEnter2D(Collider2D collison) { // Collider Handler
    if (collison.gameObject.CompareTag("Enemy")) //unused, dealing damage to the player is done in the enemies own script
    {
        currenthealth = currenthealth - 2;
    }
    else if(collison.gameObject.CompareTag("Weapon")) //unused, dealing damage to the player is done in the enemies own script
    {
        currenthealth = currenthealth - 2;
    } else if (collison.gameObject.CompareTag("HealthPotion")){ // Health Potion Code, if the player collides with a health potion it increases the health
        currenthealth = currenthealth + 15;
        if(currenthealth > 100) {
            currenthealth = 100;
        }
        Sethealth(); // sets the slider bar to the new adjusted value
        potion.Play();
        Destroy(collison.gameObject, 0f);
    } else if (collison.gameObject.CompareTag("TreasureChest")) { // Treasure Chest code, if clears the level when touched
        SceneManager.LoadScene("clearLvl");
    }

}
    public void takedamage(int damage) { // attached to the player, when hit by the enemies, they will take and activate this function, which will deal damage to the player
        Debug.Log("Hit!");
        currenthealth -= damage;
        Debug.Log(currenthealth);
        Sethealth(); // sets the slider bar to the new adjusted value
        if (currenthealth <= 0) {
            gameOverText.text = "Game Over! Press 'R' to restart!";
            Destroy(gameObject, 0f);
            isGameOver = true;
        }
    }
    public void Sethealth() { // sets the health bar to the coorect value based on player health
        slider.value = currenthealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
