using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Если враг касается луча
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("EnemyPooling");
            ObjectPooling Pool = enemy.GetComponent<ObjectPooling>();
            Pool.ReturnObject(other.gameObject); // Мгновенно уничтожаем врага
            GameManager.Instance.EnemyKilled();
        }
    }
}
