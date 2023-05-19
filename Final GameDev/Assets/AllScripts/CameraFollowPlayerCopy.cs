using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CameraFollowPlayerCopy : MonoBehaviour
{
    // Default values
    public float followSpeed = 2f;
    public float yOffset = 1f; 
    public float xOffset = 10f;
    public float zOffset = -15f;
    public Transform target; // player
    [SerializeField] private TMP_Text gameOverText; // text to indicate when game over occurs

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // focuses on following the player and game over
    {
        if (target == null || target.position.y < -94.5) // if target is destoryed or is below a certain height, we pause the scene and give a game over text
        {
            gameOverText.text = "Game Over! Press 'R' to restart!";
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R)) // After the text has been shown and the scene has been paused, the player can press R to restart the level
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset , target.position.z + zOffset);
            transform.position = Vector3.Lerp(transform.position,newPos,followSpeed*Time.deltaTime);        
    }
}
