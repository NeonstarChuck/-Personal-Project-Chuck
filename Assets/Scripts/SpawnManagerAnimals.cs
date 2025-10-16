using UnityEngine;

public class SpawnManagerAnimals : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] animalPrefabs;
    public Transform[] spawnPoints;

    public float startDelay = 2f;
    public float spawnInterval = 3f;

    void Start()
    {
         InvokeRepeating(nameof(SpawnAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void SpawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPoints[spawnIndex].position,
            spawnPoints[spawnIndex].rotation
        );
    }
}
