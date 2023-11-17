using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    private float spawnInterval = 5f;
    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // 시간 경과 확인
        timeSinceLastSpawn += Time.deltaTime;

        // 일정 간격마다 프리팹 생성
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0f; // 시간 초기화
        }
    }

    void SpawnPrefab()
    {
        // 프리팹 생성
        if (prefabToSpawn != null && spawnPoint != null)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Prefab or spawn point is not assigned!");
        }
    }
}
