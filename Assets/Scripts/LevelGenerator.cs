using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks = new GameObject[12];
    void Start()
    {
        ChunkSpawn();
    }
    void Update()
    {
        MoveChunks();
    }

    void ChunkSpawn()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            float chunkPosZ = transform.position.z + (i * chunkLength);
            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, chunkPosZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
            chunks[i] = newChunk;
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward*(moveSpeed*Time.deltaTime));
        }
    }
}
