using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is responsible for coin collection, when a user collides with a coin, it increases the coin count and destroys the coin, it is displayed in the text
public class ItemCollectorCopy : MonoBehaviour
{
    private int coins = 0;
    public AudioSource coinSFX;
    [SerializeField] private TMP_Text CoinsCollected;
   private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Coin"))
    {
        Destroy(collison.gameObject);
        coinSFX.Play();
        coins++;
        CoinsCollected.text = "Coins Collected: " + coins;
    }
   }
}
