using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2f; // Скорость движения
    public float moveRange = 7f; // Дальность движения влево-вправо
    public float minStopTime = 1f; // Минимальное время остановки
    public float maxStopTime = 3f; // Максимальное время остановки

    private Vector3 startPosition;
    private bool movingRight = true;

    void OnEnable()
    {
        startPosition = transform.position;
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            float targetX = startPosition.x + (movingRight ? moveRange : -moveRange);
            while (Mathf.Abs(transform.position.x - targetX) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
                yield return null;
            }

            // Остановка на случайное время
            float stopTime = Random.Range(minStopTime, maxStopTime);
            yield return new WaitForSeconds(stopTime);

            movingRight = !movingRight; // Меняем направление
        }
    }
}
