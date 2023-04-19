using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab; // 积己且 Enemy 橇府普
    public Transform[] spawnPoints;

    public float spawnInterval = 3f; // 利 积己 埃拜
    private float spawnTimer = 0f; // 利 积己 鸥捞赣

    void Update()
    {
        // 利 积己 鸥捞赣 诀单捞飘
        spawnTimer += Time.deltaTime;

        // 利 积己 埃拜付促 利 积己
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