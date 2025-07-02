using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float minX = -5f; // ����� �������
    public float maxX = 5f;  // ������ �������
    public float speed = 5f; // �������� ���������

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetX = Mathf.Clamp(mousePosition.x, minX, maxX); // ������������ �� X

        // ������� �������� � ����
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetX, speed * Time.deltaTime),
            transform.position.y,
            transform.position.z
        );
    }
}
