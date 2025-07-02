using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public ObjectPooling objectPool;
    public Transform[] rows; // ��� ����� ��� �����

    public float row1Y = 0f; // Y ���������� ������� ����
    public float row2Y = 2f; // Y ���������� ������� ����
    public float row3Y = 4f; // Y ���������� �������� ����

    public float rowTolerance = 0.5f; // ����������� ��� ����������� ����

    public int maxEnemies = 5; // ����� ���������� ������
    public float spawnCheckInterval = 2f; // ����� ����� ����������, ����� �� ���������� ������
    List<int> emptyRows = new List<int>();

    public List<GameObject>[] rowEnemies; // ����� � ������ ����

    private int spawnedEnemies = 0; // ������� ������ ��� �������

    void Start()
    {
        rowEnemies = new List<GameObject>[rows.Length];
        for (int i = 0; i < rows.Length; i++)
        {
            rowEnemies[i] = new List<GameObject>();
        }

        row1Y = rows[0].transform.position.y;
        row2Y = rows[1].transform.position.y;
        row3Y = rows[2].transform.position.y;

        StartCoroutine(SpawnEnemies());
    }

    // ������� ��� ����������� ���� �� ������� �����
    public int GetEnemyRow(float enemyY)
    {
        if (Mathf.Abs(enemyY - row1Y) <= rowTolerance)
        {
            return 0; // ���� � ������ ����
        }
        else if (Mathf.Abs(enemyY - row2Y) <= rowTolerance)
        {
            return 1; // ���� �� ������ ����
        }
        else if (Mathf.Abs(enemyY - row3Y) <= rowTolerance)
        {
            return 2; // ���� � ������� ����
        }
        else
        {
            return -1; // ���� �� � ����� �� ����
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnedEnemies < maxEnemies)
        {
            Debug.Log(spawnedEnemies);
            yield return new WaitForSeconds(spawnCheckInterval);
            TrySpawnEnemy();
        }
    }

    void TrySpawnEnemy()
    {
        // �������� ��������� ��� � ������������ ������ �����
        emptyRows.Clear();
        for (int i = 0; i < rows.Length; i++)
        {
            // ���������, ���� �� �������� ����� � ���� ����
            bool rowIsEmpty = true;
            foreach (var enemy in rowEnemies[i])
            {
                if (enemy.activeInHierarchy) // ���� ���� �� ���� ���� �������, ��� �� ����
                {
                    rowIsEmpty = false;
                    break;
                }
            }

            if (rowIsEmpty)
                emptyRows.Add(i);
        }

        if (emptyRows.Count > 0)
        {
            // �������� ��������� ���, ��� ����� ���������� ������ �����
            int rowIndex = emptyRows[Random.Range(0, emptyRows.Count)];
            GameObject enemy = objectPool.GetObject();
            enemy.transform.position = rows[rowIndex].position;
            enemy.transform.parent = rows[rowIndex]; // ����������� ����� � ����
            rowEnemies[rowIndex].Add(enemy); // ��������� ����� � ������ ����

            spawnedEnemies++;
        }
    }
}
