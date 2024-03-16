using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPrefabManager : MonoBehaviour
{
    public static AnimationPrefabManager Instance;
    [Header("Prefab")]
    [SerializeField] private GameObject brokenBlockPrefab;
    [SerializeField] private GameObject textPerfectPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnBrokenBlockAnimation(Vector2 spawnPosition)
    {
        GameObject broken = Instantiate(brokenBlockPrefab, spawnPosition, Quaternion.identity);
        if (spawnPosition.x < 0)
        {
            broken.transform.Rotate(0, 180, 0);
        }
    }
    public void SpawnPerfectTextAnimation(Vector2 spawnPosition)
    {
        Instantiate(textPerfectPrefab, spawnPosition, Quaternion.identity);

    }
}
