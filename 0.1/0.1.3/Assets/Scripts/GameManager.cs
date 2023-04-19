using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove playerMove;

    public GameObject[] bossObjs;
    public GameObject[] eliteObjs;
    public GameObject[] BomerObjs;
    public GameObject[] enemyObjs;

    public Transform[] bossPoints;
    public Transform[] elitePoints;
    public Transform[] BomerPoints;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            spawnBomer();
            spawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
    }

    void spawnBoss()
    {
        Instantiate(bossObjs[0], bossPoints[0].position, bossPoints[0].rotation * Quaternion.Euler(0f, 180f, 0f));
    }

    void spawnElite()
    {
        int ranPoint = Random.Range(0, 2);
        Instantiate(eliteObjs[0], elitePoints[ranPoint].position, elitePoints[ranPoint].rotation * Quaternion.Euler(0f, 180f, 0f));
    }

    void spawnBomer()
    {
        int ranPoint = Random.Range(0, 2);
        Instantiate(BomerObjs[0], BomerPoints[ranPoint].position, BomerPoints[ranPoint].rotation * Quaternion.Euler(0f, 180f, 0f));
    }

    void spawnEnemy()
    {
        int ranEnemy = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 7);
        Instantiate(enemyObjs[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation * Quaternion.Euler(0f, 180f, 0f));
    }
}
