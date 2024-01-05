using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> chunks;
    [SerializeField] private GameObject player;
    [SerializeField] private float checkerRadius;
    [SerializeField] private LayerMask mask;
    [SerializeField] private List<GameObject> spawnedChunks;
    [SerializeField] private float maxDist;
    [SerializeField] private float cdDuration;
    [SerializeField] private GameObject currentChunk;
    public GameObject CurrentChunk
    {
        get { return currentChunk; }
        set { currentChunk = value; }
    }
    Vector3 noPos;
    GameObject latestChunk;
    float dist;
    float cd;

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }
    void ChunkCheckerDir(string direction)
    {
        if (!Physics2D.OverlapCircle(currentChunk.transform.Find(direction).position, checkerRadius, mask))
        {
            noPos = currentChunk.transform.Find(direction).position;
            SpawnChunk();
        }
    }
    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        ChunkCheckerDir("Right");
        ChunkCheckerDir("Left");
        ChunkCheckerDir("Up");
        ChunkCheckerDir("Down");
        ChunkCheckerDir("Right up");
        ChunkCheckerDir("Right down");
        ChunkCheckerDir("Left up");
        ChunkCheckerDir("Left down");
    }
    void SpawnChunk()
    {
        int random = Random.Range(0, chunks.Count);
        latestChunk = Instantiate(chunks[random], noPos, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }
    void ChunkOptimizer()
    {
        cd -= Time.deltaTime;

        if (cd <= 0f)
        {
            cd = cdDuration;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            dist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (dist > maxDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
