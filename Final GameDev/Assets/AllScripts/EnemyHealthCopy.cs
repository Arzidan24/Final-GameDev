using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script focuses on moving the enemy health bar along with the enemy movement
public class EnemyHealthCopy : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(playerTransform == null) {
            return;
        } else {
        // Update the position of the canvas to match the position of the player
        transform.position = playerTransform.position + offset;
        }
    }
}
