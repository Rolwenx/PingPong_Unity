using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    
    public GameObject[] powerUpPrefabs; 
    public float spawnInterval = 10f; // Interval between power-up spawns
    public float spawnRange = 5f; // Range along the top of the screen to spawn power-ups
    public Transform topBorder; // Transform of the top border of the screen

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Initialize next spawn time
    }

    private void Update()
    {
        // Check if it's time to spawn a new power-up
        if (Time.time >= nextSpawnTime)
        {
            // Calculate a random X position within the spawn range
            float randomX = Random.Range(topBorder.position.x - spawnRange, topBorder.position.x + spawnRange);
            // Ensure the Y position is at the top of the screen
            Vector2 spawnPosition = new Vector2(randomX, topBorder.position.y);
            
            // Spawn a random power-up prefab at the calculated position
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);
            GameObject newPowerUp = Instantiate(powerUpPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            // Reset the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    
}