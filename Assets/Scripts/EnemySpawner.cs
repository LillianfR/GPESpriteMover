using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject asteroidPrefab;

    // How many seconds to wait between each asteroid spawn
    public float spawnRate = 2f;

    [Header("Boundary Settings")]
    //width of your screen where asteroids can appear left to right
    public float minX = -8f;
    public float maxX = 8f;
    
    //height above the screen view where asteroids will pop into existence
    public float spawnY = 6f;

    private void Start()
    {
        //starts repeating timer that calls the SpawnAsteroid 
        InvokeRepeating("SpawnAsteroid", 0.5f, spawnRate);
    }

    private void SpawnAsteroid()
    {
        // random position on the x axis within the defined areas
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        //spawns new astroid prefab
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
