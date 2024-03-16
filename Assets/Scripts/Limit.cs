using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision != null && collision.tag == "Tile")
        {
            GameManager.Instance.SpawnTile(Random.Range(3, 7));
            //GameManager.Instance.SpawnTileManager.RemoveToXPositionQueue();
        }
    }
}
