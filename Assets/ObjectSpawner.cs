using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectSpawner : MonoBehaviour
{
    public GameManager gm;

    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    private float spawnInterval = 5f;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }
    void Update()
    {
        // �ð� ��� Ȯ��
        timeSinceLastSpawn += Time.deltaTime;

        // ���� ���ݸ��� ������ ����
        if (timeSinceLastSpawn >= spawnInterval)
        {
            if (!gm.Stop)
            {
                SpawnPrefab();
            }
            timeSinceLastSpawn = 0f; // �ð� �ʱ�ȭ
        }
    }

    void SpawnPrefab()
    {
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
