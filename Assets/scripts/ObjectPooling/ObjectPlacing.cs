using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

public class ObjectPlacing : MonoBehaviour
{
   
    public ObjectPooling objectPool;   // Пул объектов
    public float spawnInterval = 2f;  // Интервал между спавнами
   
    public float maxAngle = 180f;
    public float radius = 2f;// Максимальный угол наклона препятствий
    public Transform player;        // Позиция игрока

  

  

    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

   

    void SpawnObstacle()
    {

        GameObject obstacle = objectPool.GetObject();

        







    }


}
