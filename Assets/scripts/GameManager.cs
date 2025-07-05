using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int enemiesToWin = 10; // ������� ������ ����� ����� ��� ������
    public int enemiesKilled = 0;
    public float wait = 2f;
    public string SceneName;

    public static GameManager Instance { get; private set; } // �������� GameManager

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
    

   

    public void EnemyKilled()
    {
        enemiesKilled++;
       

        if (enemiesKilled >= enemiesToWin)
        {
            Invoke("LevelCompleted", wait); // ������� MyMethod ����� 2 �������
        }
    }

    private void LevelCompleted()
    {
        
        SceneManager.LoadScene(SceneName); // �� ����� �����
    }
}
