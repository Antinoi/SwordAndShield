using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int maxHealth = 5; // Максимальное количество жизней
    private int currentHealth; // Текущие жизни врага

    public string damageTag = "Bullet"; // Тэг объекта, который наносит урон



    void Start()
    {
        // Устанавливаем начальное количество жизней
        currentHealth = maxHealth;

        
    }

    // Метод, который вызывается при столкновении с другими объектами
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        // Если объект с тегом, который наносит урон, сталкивается с врагом
        if (collider.gameObject.CompareTag(damageTag))
        {

            GameObject bulletP = GameObject.FindGameObjectWithTag("BulletPooling");
            ObjectPooling Pool = bulletP.GetComponent<ObjectPooling>();
            Pool.ReturnObject(collider.gameObject);
            // Уменьшаем жизни врага
            TakeDamage(1);
        }
    }

    // Метод для уменьшения здоровья
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        // Если жизни врага опускаются до нуля, враг умирает
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод для уничтожения врага
    void Die()
    {
      

        EnemyPlacer enemyScript = Object.FindFirstObjectByType<EnemyPlacer>();
        
        enemyScript.rowEnemies[enemyScript.GetEnemyRow(transform.position.y)].Clear();


        GameObject enemieP = GameObject.FindGameObjectWithTag("EnemyPooling");
        ObjectPooling Pool = enemieP.GetComponent<ObjectPooling>();
        Pool.ReturnObject(gameObject);

        GameManager.Instance.EnemyKilled();

    }
}
