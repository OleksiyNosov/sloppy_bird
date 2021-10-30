using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] GameObject barrierPrefab;
    [SerializeField] Vector2 barrierStartPotion = new Vector2(10f, 3.5f);
    [SerializeField] float spawnInterval = 5f;

    private float lastSpawnTime = 0f;

    private void Update()
    {
        lastSpawnTime += Time.deltaTime;

        if (lastSpawnTime >= spawnInterval)
        {
            lastSpawnTime = 0f;

            Instantiate(barrierPrefab, barrierStartPotion, Quaternion.identity);
        }
    }
}
