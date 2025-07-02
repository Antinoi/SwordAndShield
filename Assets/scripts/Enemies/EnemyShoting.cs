using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySooting : MonoBehaviour
{
    public ObjectPooling objectPool;   // ��� ��������

    public Transform firePoint; // �������, �� ������� �������� ��������

    public Vector2 shootDirection = Vector2.down;
    public float shootInterval = 0.5f; // �������� ����� ����������
    public float squareSpeed = 5f; // �������� �����������
    public float destroyAfter = 3f; // ����� �����������, ���� �� �����������
    private float randomDelay; // ��������� ��������, ����� ������ �������� �� ������������

    private float nextShootTime = 0f;


    void Start()
    {
        // �������������� ��������� ��������
        randomDelay = Random.Range(0f, shootInterval+1);
        nextShootTime = Time.time + randomDelay; // �������� ����� ������ ���������

    }

    void Update()
    {

        if (Time.time >= nextShootTime) // ��������� ���
        {
            Shoot();
            nextShootTime = Time.time + shootInterval; // ��������� ������� ����� ��������
        }
    }

    void Shoot()
    {
        GameObject square = objectPool.GetObject();
        square.transform.position = firePoint.position;
        Rigidbody2D rb = square.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = shootDirection * squareSpeed; // ������� ��������� ������

        }

        StartCoroutine(DestroyAfterTime(square, destroyAfter));
    }

    IEnumerator DestroyAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.ReturnObject(obj);
    }
}
