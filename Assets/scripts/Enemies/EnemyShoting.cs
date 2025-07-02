using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySooting : MonoBehaviour
{
    public ObjectPooling objectPool;   // Пул объектов

    public Transform firePoint; // Позиция, из которой вылетают квадраты

    public Vector2 shootDirection = Vector2.down;
    public float shootInterval = 0.5f; // Интервал между выстрелами
    public float squareSpeed = 5f; // Скорость квадратиков
    public float destroyAfter = 3f; // Время уничтожения, если не столкнулись
    private float randomDelay; // Случайная задержка, чтобы начать стрелять не одновременно

    private float nextShootTime = 0f;


    void Start()
    {
        // Инициализируем случайную задержку
        randomDelay = Random.Range(0f, shootInterval+1);
        nextShootTime = Time.time + randomDelay; // Задержка перед первым выстрелом

    }

    void Update()
    {

        if (Time.time >= nextShootTime) // Удержание ЛКМ
        {
            Shoot();
            nextShootTime = Time.time + shootInterval; // Следующий выстрел через интервал
        }
    }

    void Shoot()
    {
        GameObject square = objectPool.GetObject();
        square.transform.position = firePoint.position;
        Rigidbody2D rb = square.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = shootDirection * squareSpeed; // Двигаем квадратик вправо

        }

        StartCoroutine(DestroyAfterTime(square, destroyAfter));
    }

    IEnumerator DestroyAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.ReturnObject(obj);
    }
}
