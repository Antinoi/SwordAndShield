using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 5; // ������������ ���������� ������
    private int currentHealth; 

    public string damageTag = "EnemyBullet"; // ��� �������, ������� ������� ����

    public Slider healthBar; // ������ �� UI-������� ��������
    public Image healthFill; // �������� ������� (Fill Area)

    void Start()
    {
        // ������������� ��������� ���������� ������
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    // ���������� UI-�������
    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
            float healthPercent = (float)currentHealth / maxHealth;
            healthFill.color = Color.Lerp(Color.red, Color.green, healthPercent);
        }
    }

    // �����, ������� ���������� ��� ������������ � ������� ���������
    void OnTriggerEnter2D(Collider2D collider)
    {

        // ���� ������ � �����, ������� ������� ����, ������������ � ������
        if (collider.gameObject.CompareTag(damageTag))
        {
            collider.gameObject.SetActive(false);
            // ��������� ����� �����
            TakeDamage(1);
        }
    }

    // ����� ��� ���������� ��������
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthBar();
        // ���� ����� ����� ���������� �� ����, ���� �������
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

    // ����� ��� ����������� �����
    void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
