using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab; // ������ Enemy ������
    public Transform[] spawnPoints;

    public float spawnInterval = 3f; // �� ���� ����
    private float spawnTimer = 0f; // �� ���� Ÿ�̸�

    void Update()
    {
        // �� ���� Ÿ�̸� ������Ʈ
        spawnTimer += Time.deltaTime;

        // �� ���� ���ݸ��� �� ����
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnInterval = Random.Range(0.5f, 3f);
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyPrefab[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}