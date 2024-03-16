using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiManager : MonoBehaviour
{
    [SerializeField] private GameObject kunaiPrefab;
    public static KunaiManager Instance;
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
  
    public void SpawnKunai(List<GameObject> targets)
    {
        foreach(GameObject target in targets)
        {
            Vector2 spawnPosition = PlayerManager.Instance.player.gameObject.transform.position;
            GameObject kunai = Instantiate(kunaiPrefab, spawnPosition, Quaternion.identity);
            kunai.GetComponent<Kunai>().SetTarget(target);
        }
    }
}
