using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class bulletLife : MonoBehaviour
{
    public float destroyAfter = 3f; // Время уничтожения, если не столкнулись
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(gameObject, destroyAfter));
    }

    IEnumerator DestroyAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
