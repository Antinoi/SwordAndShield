using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public ObjectPooling objectPool;   // Пул объектов
    
    public Transform firePoint; // Позиция, из которой вылетают квадраты

    public Vector2 shootDirection = Vector2.up;
    public float shootInterval = 0.2f; // Интервал между выстрелами
    public float squareSpeed = 5f; // Скорость квадратиков
    public float destroyAfter = 3f; // Время уничтожения, если не столкнулись

   
    public GameObject shield;

    public Ultimates ultimates;
    private float nextShootTime = 0f;
   

    private bool isShooting = false;
    private bool isShielding = false;

    private void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= nextShootTime && !isShielding && !ultimates.isSwordUltimateActive) // Удержание ЛКМ
        {
            Shoot();
            nextShootTime = Time.time + shootInterval; // Следующий выстрел через интервал
        }
        else 
        {
            isShooting = false;
        }

        if (Input.GetMouseButton(1) && !isShooting && !ultimates.isSwordUltimateActive && !ultimates.isShieldUltimateActive) // Удержание ЛКМ
        {
            Shield();
            
        }
        else
        {
            shield.SetActive(false);
            isShielding = false;
        }
    }

    void Shield()
    {
        isShielding = true;
        shield.SetActive(true);
        
    }


    void Shoot()
    {
        isShooting = true;
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
