using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject dialogueCanvas;
    void Start()
    {
        pauseMenu.SetActive(false);
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            

            if (isPaused)
            {
                
                ResumeGame();
            }
            else
            {
               
                PauseGame();
            }
        }
        
    }


    public void PauseGame()
    {
      
        pauseMenu?.SetActive(true);
        dialogueCanvas?.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
        dialogueCanvas?.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        // Загружаем текущую сцену снова
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        // Загружаем текущую сцену снова
        SceneManager.LoadScene("before");
    }
}
