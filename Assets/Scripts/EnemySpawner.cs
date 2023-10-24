using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float playerDetectionRadius = 5f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private Transform playerTransform;
    private float timer = 0f;

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn) {
            if (Vector3.Distance(transform.position, playerTransform.position) > playerDetectionRadius) {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
            yield return wait;

            // Reduce spawn rate every 30 seconds
            timer += spawnRate;
            if (timer >= 30f) {
                spawnRate -= 1f;
                timer = 0f;
            }
        }
    }
}
