using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRadius = 4f;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float timeBetweenSpawns = 10f;
    private float initialTimeBetweenSpawns;
    [SerializeField] float minSpawnTime = 0.15f;
    [SerializeField] float spawnDecreaseRate = 0.1f;
    private bool GameNotExecuting = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        GameEvents.PlayerDied.AddListener(GameIsOver);
        GameEvents.GameRestart.AddListener(RestartSpawner);
        initialTimeBetweenSpawns = timeBetweenSpawns;
    }

    IEnumerator SpawnRoutine()
    {
        while (!GameNotExecuting)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
            if (timeBetweenSpawns >= minSpawnTime) timeBetweenSpawns -= spawnDecreaseRate;
            else timeBetweenSpawns = minSpawnTime;
        }
    }

    void SpawnEnemy()
    {
        if (GameNotExecuting)
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(
            enemy,
            new Vector3(
                spawnPoints[spawnPointIndex].position.x + Random.Range(-spawnRadius, spawnRadius),
                spawnPoints[spawnPointIndex].position.y + Random.Range(-spawnRadius, spawnRadius),
                0
            ),
            Quaternion.identity
        );
    }

    void GameIsOver()
    {
        GameNotExecuting = true;
        StopAllCoroutines();
    }

    void RestartSpawner()
    {
        GameNotExecuting = false;
        timeBetweenSpawns = initialTimeBetweenSpawns;
        StartCoroutine(SpawnRoutine());
    }
}
