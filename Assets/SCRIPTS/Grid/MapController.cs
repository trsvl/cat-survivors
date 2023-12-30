using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> chunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noPos;
    public LayerMask mask;
    PlayerMovement playerMovement;
    public GameObject currentChunk;

    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxDist;
    float dist;
    float cd;
    public float cdDuration;

    
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }
    
    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right up").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Right up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right down").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Right down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left up").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Left up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left down").position, checkerRadius, mask))
            {
                noPos = currentChunk.transform.Find("Left down").position;
                SpawnChunk();
            }
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
        } else
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
