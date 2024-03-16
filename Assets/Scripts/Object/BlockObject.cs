using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Kunai")
        {
            AnimationPrefabManager.Instance.SpawnBrokenBlockAnimation(transform.position);
            AnimationPrefabManager.Instance.SpawnPerfectTextAnimation(transform.position);

            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0); 
        }
    }
}
