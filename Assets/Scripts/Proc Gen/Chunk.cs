using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab; 
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    LevelGenerator levelGenerator;

    List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
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
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levelGenerator);
    }

    void SpawnCoin()
    {
        if (availableLanes.Count <= 0 || Random.value > coinSpawnChance) return;

        int selectedLane = SelectLane();

        int maxCoinToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }    
}
