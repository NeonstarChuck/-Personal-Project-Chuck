using UnityEngine;
using System.Collections;

public class SpawnManagerAnimals : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public void SpawnAnimals(int count, Transform[] spawnPoints, float spawnDelay = 5f)
    {
        StartCoroutine(SpawnAnimalsCoroutine(count, spawnPoints, spawnDelay));
    }

    private IEnumerator SpawnAnimalsCoroutine(int count, Transform[] spawnPoints, float spawnDelay)
    {
        for (int i = 0; i < count; i++)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            GameObject spawned = Instantiate(
                animalPrefabs[animalIndex],
                spawnPoints[spawnIndex].position,
                spawnPoints[spawnIndex].rotation
            );

            // Assign GameManager dynamically
            AnimalHealth health = spawned.GetComponent<AnimalHealth>();
            if (health != null)
            {
                health.gameManager = GameObject.FindAnyObjectByType<GameManager>();
            }

            yield return new WaitForSecondsRealtime(spawnDelay);

        }
    }
}

