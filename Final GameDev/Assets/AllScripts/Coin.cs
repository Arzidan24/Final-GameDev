using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float moveDistance = 0.5f; // the distance the object should move up and down
    [SerializeField] private float moveSpeed = 1f; // the speed at which the object should move

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newYPosition = Mathf.Sin(Time.time * moveSpeed) * moveDistance; // calculate the new Y position using a sine wave
        transform.position = startPosition + Vector3.up * newYPosition; // move the object to the new position
    }
}
