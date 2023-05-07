using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
