using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab; 
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, 3);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if (availableLanes.Count <= 0 || Random.value > appleSpawnChance) return;

        int selectedLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnCoin()
    {
        if (availableLanes.Count <= 0 || Random.value > coinSpawnChance) return;

        int selectedLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }    
}
