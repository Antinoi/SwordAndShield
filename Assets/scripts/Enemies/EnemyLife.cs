using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int maxHealth = 5; // ������������ ���������� ������
    private int currentHealth; // ������� ����� �����

    public string damageTag = "Bullet"; // ��� �������, ������� ������� ����



    void Start()
    {
        // ������������� ��������� ���������� ������
        currentHealth = maxHealth;

        
    }

    // �����, ������� ���������� ��� ������������ � ������� ���������
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        // ���� ������ � �����, ������� ������� ����, ������������ � ������
        if (collider.gameObject.CompareTag(damageTag))
        {

            GameObject bulletP = GameObject.FindGameObjectWithTag("BulletPooling");
            ObjectPooling Pool = bulletP.GetComponent<ObjectPooling>();
            Pool.ReturnObject(collider.gameObject);
            // ��������� ����� �����
            TakeDamage(1);
        }
    }

    // ����� ��� ���������� ��������
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        // ���� ����� ����� ���������� �� ����, ���� �������
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ��� ����������� �����
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
