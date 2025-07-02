using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

public class ObjectPlacing : MonoBehaviour
{
   
    public ObjectPooling objectPool;   // ��� ��������
    public float spawnInterval = 2f;  // �������� ����� ��������
   
    public float maxAngle = 180f;
    public float radius = 2f;// ������������ ���� ������� �����������
    public Transform player;        // ������� ������

  

  

    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

   

    void SpawnObstacle()
    {

        GameObject obstacle = objectPool.GetObject();

        







    }


}
