using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public ObjectPooling objectPool;
    public Transform[] rows; // Три точки для рядов

    public float row1Y = 0f; // Y координата первого ряда
    public float row2Y = 2f; // Y координата второго ряда
    public float row3Y = 4f; // Y координата третьего ряда

    public float rowTolerance = 0.5f; // Погрешность для определения ряда

    public int maxEnemies = 5; // Общее количество врагов
    public float spawnCheckInterval = 2f; // Время между проверками, можно ли заспавнить нового
    List<int> emptyRows = new List<int>();

    public List<GameObject>[] rowEnemies; // Враги в каждом ряду

    private int spawnedEnemies = 0; // Сколько врагов уже создано

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

    // Функция для определения ряда по позиции врага
    public int GetEnemyRow(float enemyY)
    {
        if (Mathf.Abs(enemyY - row1Y) <= rowTolerance)
        {
            return 0; // Враг в первом ряду
        }
        else if (Mathf.Abs(enemyY - row2Y) <= rowTolerance)
        {
            return 1; // Враг во втором ряду
        }
        else if (Mathf.Abs(enemyY - row3Y) <= rowTolerance)
        {
            return 2; // Враг в третьем ряду
        }
        else
        {
            return -1; // Враг не в одном из ряда
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
        // Выбираем случайный ряд с возможностью спавна врага
        emptyRows.Clear();
        for (int i = 0; i < rows.Length; i++)
        {
            // Проверяем, есть ли активные враги в этом ряду
            bool rowIsEmpty = true;
            foreach (var enemy in rowEnemies[i])
            {
                if (enemy.activeInHierarchy) // Если хотя бы один враг активен, ряд не пуст
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
            // Выбираем случайный ряд, где можно заспавнить нового врага
            int rowIndex = emptyRows[Random.Range(0, emptyRows.Count)];
            GameObject enemy = objectPool.GetObject();
            enemy.transform.position = rows[rowIndex].position;
            enemy.transform.parent = rows[rowIndex]; // Привязываем врага к ряду
            rowEnemies[rowIndex].Add(enemy); // Добавляем врага в список ряда

            spawnedEnemies++;
        }
    }
}
