using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    public string damageTag = "EnemyBullet"; // Тэг объекта, который наносит урон
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag(damageTag))
        {
            collider.gameObject.SetActive(false);
            
        }
    }

}
