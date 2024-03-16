using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Player player;

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
        SetPlayerPosition(GameManager.Instance.NextXPosition());
    }
    public void MoveToNextTile()
    {
        //GameManager.Instance.SpawnTileManager.RemoveToXPositionQueue();
        //SetPlayerPosition(GameManager.Instance.NextXPosition());
        StartCoroutine(MoveRoutine(GameManager.Instance.NextXPosition()));

    }
    private void SetPlayerPosition(float x)
    {
        Vector2 spawnPosition = new Vector2(x, player.transform.position.y);
        player.transform.position = spawnPosition;
    }
    private IEnumerator MoveRoutine(float  target)
    {
        Vector2 targetPosition = new Vector2(target, player.transform.position.y);
        while (Vector2.Distance(player.transform.position, targetPosition) > 0.1f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, targetPosition, Time.deltaTime * 10);
            yield return null;
        }
        SetPlayerPosition(target);
    }

}
