using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    
    
    public float wait = 0f;
    public string SceneTibDeadName;
    public string SceneKaelDeadName;



    private void Awake()
    {
        
    }

   

    public void loadTibDead()
    {

        SceneManager.LoadScene(SceneTibDeadName); // По имени сцены
    }

    public void loadKaelDead()
    {

        SceneManager.LoadScene(SceneKaelDeadName); // По имени сцены
    }
}
