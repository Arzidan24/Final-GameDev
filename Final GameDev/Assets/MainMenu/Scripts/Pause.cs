using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused){
                Resume();

            }
            else{
                Pause();
            }
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GoMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Apllication.Quit();
    }
}
