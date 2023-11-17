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
        // �ð� ��� Ȯ��
        timeSinceLastSpawn += Time.deltaTime;

        // ���� ���ݸ��� ������ ����
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0f; // �ð� �ʱ�ȭ
        }
    }

    void SpawnPrefab()
    {
        // ������ ����
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
