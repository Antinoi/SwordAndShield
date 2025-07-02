using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superLaser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100;
    public Transform laresFirstPoint;
    public LineRenderer lineRenderer;
    Transform m_transform;
    // Start is called before the first frame update
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.up);
            Draw2DRay(laresFirstPoint.position, _hit.point);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

}
