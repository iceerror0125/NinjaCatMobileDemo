using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SpawnTileManager : MonoBehaviour
{
    [SerializeField] private GameObject jumpTilePrefab;
    [SerializeField] private GameObject normalTilePrefab;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject bushPrefab;
    [Header("Settings")]
    [SerializeField] private float twoTileDistance = 0.7f;
    [SerializeField] private float twoGroupTileDistance = 0.4f;
    [Header("Blocks")]
    [SerializeField] private Queue<List<GameObject>> blockListQueue;
    [Header("Tiles")]
    [SerializeField] private Queue<float> xPositionBlockQueue;


    private void Awake()
    {
        blockListQueue = new Queue<List<GameObject>>();
        xPositionBlockQueue = new Queue<float>();
    }
    public void SpawnGroupTile(int tileQuantity)
    {
        GameObject jumpTile = SpawnTile(tileQuantity);
        GenerateBlock(jumpTile.transform.GetChild((tileQuantity / 2) + 1).position.y);
        GenerateBush(RandomOppositeNumber(1.5f));
    }

    public void SpawnInitGroupTile(int tileQuantity)
    {
        SpawnTile(tileQuantity);
    }
    public GameObject SpawnTile(int tileQuantity)
    {
        Vector2 latestTilePosition = GetLatestTilePosition();
        GameObject jumpTile = Instantiate(jumpTilePrefab);
        jumpTile.tag = "Tile";

        for (int i = 0; i < tileQuantity; i++)
        {
            GameObject normalTile = Instantiate(normalTilePrefab);
            normalTile.transform.parent = jumpTile.transform;
            normalTile.transform.position = new Vector2(jumpTile.transform.position.x, jumpTile.transform.position.y - 0.7f * (i + 1));
            normalTile.GetComponent<SpriteRenderer>().sortingOrder = i + 1;
        }

        float ySpawn = (tileQuantity + 1) * twoTileDistance + twoGroupTileDistance + latestTilePosition.y;
        jumpTile.transform.position = new Vector2(RandomOppositeNumber(1), ySpawn);

        jumpTile.AddComponent<MovingObject>();
        jumpTile.GetComponent<MovingObject>().SetSpeed(5);

        AddToXPositionQueue(jumpTile.gameObject.transform.position.x);

        return jumpTile;
    }

    private Vector2 GetLatestTilePosition()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Tile");
        if (gos.Length == 0)
            return Vector2.zero;

        return gos[gos.Length - 1].transform.position;
    }

    private float RandomOppositeNumber(float number)
    {
        if (Random.Range(0, 100) < 50)
            return number * -1;
        return number;
    }

    private GameObject GenerateLeftBlock()
    {
        GameObject block = Instantiate(blockPrefab);
        Debug.Log(block.transform.eulerAngles.y);
        block.transform.position = new Vector2(-2, 0);
        block.name = "left";
        return block;
    }
    private GameObject GenerateRightBlock()
    {
        GameObject block = Instantiate(blockPrefab);
        block.transform.position = new Vector2(2, 0);
        block.transform.Rotate(0, 180, 0);
        block.name = "right";

        return block;
    }
    private void GenerateBlock(float yPosition)
    {
        List<GameObject> blocks = new List<GameObject>();
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0: blocks.Add(GenerateLeftBlock()); break;
            case 1: blocks.Add(GenerateRightBlock()); break;
            case 2:
                {
                    blocks.Add(GenerateLeftBlock());
                    blocks.Add(GenerateRightBlock());
                    break;
                }
        }
        foreach (GameObject block in blocks)
        {
            Vector2 spawnPosition = new Vector2(block.transform.position.x, yPosition);
            block.transform.position = spawnPosition;
        }

        AddBlock(blocks);
    }
    private void GenerateBush(float xPosition)
    {
        if (Random.Range(0, 100) < 40)
        {
            Vector2 spawnPosition = new Vector2(xPosition, 7);
            GameObject bush = Instantiate(bushPrefab, spawnPosition, Quaternion.identity);
            if (xPosition > 0)
            {
                bush.transform.Rotate(0, 180, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Tile")
        {
            Debug.Log("Delete");
            RemoveBlock();
        }
    }

    private void AddBlock(List<GameObject> blocks)
    {
        blockListQueue.Enqueue(blocks);
    }
    private void RemoveBlock()
    {
        blockListQueue.Dequeue();
    }
    public List<GameObject> GetLatestBlockList()
    {
        return blockListQueue.Peek();
    }
    public void AddToXPositionQueue(float x)
    {
        xPositionBlockQueue.Enqueue(x);
    }
    public void RemoveToXPositionQueue()
    {
        xPositionBlockQueue.Dequeue();
    }
    public float GetNextXPosition()
    {
        return xPositionBlockQueue.Peek();
    }
}
