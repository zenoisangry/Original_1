using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    public GameObject[] objectsToCheck; // Array of objects to check for disabled status
    public float timerDuration = 15f; // Duration of the timer in seconds
    private float timer = 0f;
    private bool timerStarted = false;
    public UIGameplay timerText; // Reference to the UI Text element

    private static LevelManager _instance;
    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<LevelManager>();
            if (_instance == null)
                Debug.LogError("LevelManager not found, can't create singleton object");
            return _instance;
        }
    }

    private void Start()
    {
        NextWave();
    }

    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            SpawnEnemy();
        }

        bool allObjectsDisabled = CheckAllObjectsDisabled();

        // If all objects are disabled and the timer hasn't started, start the timer
        if (allObjectsDisabled && !timerStarted)
        {
            StartTimer();
        }

        // If the timer has started, count down
        if (timerStarted)
        {
            UpdateTimer();
        }
    }

    void SpawnEnemy()
    {
        enemiesRemainingToSpawn--;
        nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

        Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
        spawnedEnemy.OnDeath += OnEnemyDeath;
    }

    bool CheckAllObjectsDisabled()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            if (obj.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void StartTimer()
    {
        timerStarted = true;
        timer = 0f;
    }

    void UpdateTimer()
    {
        timer += Time.deltaTime;

        // If the timer reaches the duration, go to "GameWin" screen
        if (timer >= timerDuration)
        {
            UIManager.instance.ShowUI(UIManager.GameUI.GameWin);
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

    // This method finds any object of the specified type in the scene hierarchy
    static new T FindAnyObjectByType<T>() where T : Object
    {
        T[] objects = Resources.FindObjectsOfTypeAll<T>();
        if (objects.Length > 0)
        {
            return objects[0];
        }
        return null;
    }
}