using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTileController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameManager.Instance.SpawnTileManager.RemoveToXPositionQueue();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            float x = GameManager.Instance.SpawnTileManager.GetNextXPosition();
            if (player.transform.position.x == x * -1)
            {
                Time.timeScale = 0;
                PopUpManager.Instance.ShowGameOverText();
                AudioManager.Instance.StopBG();
            }
        }
    }
}
