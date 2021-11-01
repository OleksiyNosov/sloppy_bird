using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] GameObject barrierPrefab;
    [SerializeField] Vector2 barrierStartPotion = new Vector2(10f, 3.5f);
    [SerializeField] float verticalOffsetDelat = 1f;
    [SerializeField] float spawnInterval = 5f;

    private bool spawnActive = true;
    private float lastSpawnTime = 0f;
    
    public void Reset()
    {
        spawnActive = true;
        lastSpawnTime = 0;
        
        var barriers = FindObjectsOfType<Barrier>();
        foreach (var barrier in barriers)
        {
            barrier.gameObject.SetActive(false);
            Destroy(barrier.gameObject);
        }
    }

    public void Stop()
    {
        spawnActive = false;

        var barriers = FindObjectsOfType<Barrier>();

        foreach (var barrier in barriers)
        {
            barrier.Stop();
        }
    }

    private void Update()
    {
        if (!spawnActive)
            return;

        lastSpawnTime += Time.deltaTime;

        if (lastSpawnTime >= spawnInterval)
        {
            lastSpawnTime = 0f;
            
            SpawnBarrier();
        }
    }

    private void SpawnBarrier()
    {
        var verticalOffset = Random.Range(-verticalOffsetDelat, verticalOffsetDelat);
        var offset = new Vector2(0f, verticalOffset);

        Instantiate(barrierPrefab, barrierStartPotion + offset, Quaternion.identity);
    }
}
