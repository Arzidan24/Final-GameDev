using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private TMP_Text CoinsCollected;
   private void OnTriggerEnter2D(Collider2D collison) {
    if (collison.gameObject.CompareTag("Coin"))
    {
        Destroy(collison.gameObject);
        coins++;
        CoinsCollected.text = "Coins Collected: " + coins;
    }
   }
}
