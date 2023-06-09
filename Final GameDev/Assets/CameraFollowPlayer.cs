using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CameraFollowPlayer : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 1f; //if we want to follow the player height while jumping, unused
    public float xOffset = 10f;
    public float zOffset = -15f;
    public Transform target;
    [SerializeField] private TMP_Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || target.position.y < -94.5)
        {
            gameOverText.text = "Game Over! Press 'R' to restart!";
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset , target.position.z + zOffset);
            transform.position = Vector3.Lerp(transform.position,newPos,followSpeed*Time.deltaTime);        
    }
}
