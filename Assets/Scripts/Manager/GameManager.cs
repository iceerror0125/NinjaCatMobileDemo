using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private SpawnTileManager spawnTileManager;
    public SpawnTileManager SpawnTileManager { get { return spawnTileManager; } }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        spawnTileManager.SpawnInitGroupTile(15);
        for (int i = 0; i < 5; i++)
        {
            spawnTileManager.SpawnGroupTile(Random.Range(3, 7));
        }
        AudioManager.Instance.PlayBG();
    }
    public void SpawnTile(int tileQuantity)
    {
        spawnTileManager.SpawnGroupTile(tileQuantity);
    }
    public List<GameObject> GetNearestBlockList()
    {
        return spawnTileManager.GetLatestBlockList();
    }
    public float NextXPosition()
    {
        return spawnTileManager.GetNextXPosition();
    }
}
