using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int enemiesToWin = 10; // Сколько врагов нужно убить для победы
    public int enemiesKilled = 0;
    public float wait = 2f;
    public string SceneName;

    public static GameManager Instance { get; private set; } // Синглтон GameManager

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Update()
    {
        // Проверяем, была ли нажата клавиша "R"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart();
        }
    }

    void Restart()
    {
        // Загружаем текущую сцену снова
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
       

        if (enemiesKilled >= enemiesToWin)
        {
            Invoke("LevelCompleted", wait); // Вызовет MyMethod через 2 секунды
        }
    }

    private void LevelCompleted()
    {
        
        SceneManager.LoadScene(SceneName); // По имени сцены
    }
}
