using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnAfter;
    float timer;

    [SerializeField] GameObject player;

    private void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            SpawnEnemy();
            timer = spawnAfter;
        }
    }

    private Vector3 GenerateRandomSpawnPosition() {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f) {
            // Random X position, Max Y position
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else {
            //  Opposite
            position.x = spawnArea.x * f;
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }
        position.z = 0f;
        return position;
    }

    private void SpawnEnemy() {
        
        Vector3 position = GenerateRandomSpawnPosition();
        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }
}
