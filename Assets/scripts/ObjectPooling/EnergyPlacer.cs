using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPlacer : MonoBehaviour
{
    public ObjectPooling? SwordPool;
    public ObjectPooling? ShieldPool;
    public float spawnInterval = 10f; // Как часто спавнить
    public float spawnXMin = -7f, spawnXMax = 7f; // Диапазон по X
    public float spawnY = 6f; // Высота спавна

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnergy), 1f, spawnInterval);
    }

    void SpawnEnergy()
    {
        float xPosition = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(xPosition, spawnY, 0);

        if (ShieldPool != null && SwordPool != null) {
            GameObject energyPrefab = Random.value > 0.5f ? SwordPool.GetObject() : ShieldPool.GetObject();
            energyPrefab.transform.position = spawnPosition;
        }
        else if (ShieldPool == null)
        {
            GameObject energyPrefab = SwordPool.GetObject();
            energyPrefab.transform.position = spawnPosition;
        }else if (SwordPool == null)
        {
            GameObject energyPrefab = ShieldPool.GetObject();
            energyPrefab.transform.position = spawnPosition;
        }       
    }
}
