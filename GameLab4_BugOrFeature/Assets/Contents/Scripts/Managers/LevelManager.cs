using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static PowerUpsManager;

public class LevelManager : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;
    public GameObject legsPowerUpObject;
    public GameObject torsoPowerUpObject;
    public GameObject armsPowerUpObject;
    public GameObject headPowerUpObject;
    public Transform[] spawnPoints; // Array of spawn points
    public Collider winCollider;

    Wave currentWave;
    int currentWaveNumber;

    private int collectedPowerUps = 0;
    private bool allPowerUpsCollected = false;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    private static LevelManager _instance;
    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<LevelManager>();
            if (_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance;
        }
    }

    void Start()
    {
        SpawnPowerUp(legsPowerUpObject);
    }
    void SpawnPowerUp(GameObject powerUpPrefab)
    {
        Instantiate(powerUpPrefab, spawnPoints[collectedPowerUps].position, Quaternion.identity);
    }
    public void CollectPowerUp()
    {
        collectedPowerUps++;

        if (collectedPowerUps >= spawnPoints.Length)
        {
            allPowerUpsCollected = true;
            // Start timer here
            Debug.Log("All power-ups collected. Timer started.");
        }
        else
        {
            switch (collectedPowerUps)
            {
                case 1:
                    SpawnPowerUp(torsoPowerUpObject);
                    break;
                case 2:
                    SpawnPowerUp(armsPowerUpObject);
                    break;
                case 3:
                    SpawnPowerUp(headPowerUpObject);
                    break;
            }
        }
    }
    void Update()
    {
        Debug.Log(collectedPowerUps);
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }
    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }
    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;

            // Spawn the wave here
            // Implement your spawning logic
        }
    }
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}