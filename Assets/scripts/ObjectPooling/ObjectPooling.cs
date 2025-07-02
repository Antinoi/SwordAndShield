using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;  // Префаб для объектов
    public int poolSize = 10;  // Размер пула объектов

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        // Создаём пул объектов
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);  // Делаем объект неактивным, чтобы не мешал
            pool.Enqueue(obj);
        }
    }

    // Получить объект из пула
    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // Если объекты закончились, создаём новый
            GameObject obj = Instantiate(prefab);
            
            return obj;
        }
    }

    // Возвращаем объект в пул
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }


    // Получить все объекты, находящиеся в пуле
    public Queue<GameObject> GetAllObjects()
    {
        return pool;  // Возвращаем список всех объектов
    }
}
