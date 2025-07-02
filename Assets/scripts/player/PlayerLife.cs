using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 5; // Максимальное количество жизней
    private int currentHealth; 

    public string damageTag = "EnemyBullet"; // Тэг объекта, который наносит урон

    public Slider healthBar; // Ссылка на UI-полоску здоровья
    public Image healthFill; // Картинка заливки (Fill Area)

    void Start()
    {
        // Устанавливаем начальное количество жизней
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    // Обновление UI-полоски
    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
            float healthPercent = (float)currentHealth / maxHealth;
            healthFill.color = Color.Lerp(Color.red, Color.green, healthPercent);
        }
    }

    // Метод, который вызывается при столкновении с другими объектами
    void OnTriggerEnter2D(Collider2D collider)
    {

        // Если объект с тегом, который наносит урон, сталкивается с врагом
        if (collider.gameObject.CompareTag(damageTag))
        {
            collider.gameObject.SetActive(false);
            // Уменьшаем жизни врага
            TakeDamage(1);
        }
    }

    // Метод для уменьшения здоровья
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthBar();
        // Если жизни врага опускаются до нуля, враг умирает
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(int Amount)
    {
        currentHealth += Amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // Метод для уничтожения врага
    void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
