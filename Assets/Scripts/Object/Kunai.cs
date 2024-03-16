using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    private GameObject target;
    private bool isMoving;

    void Update()
    {
        if (isMoving)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            isMoving = false;
            transform.parent = collision.transform;

        }
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;

        if (target != null && target.transform.position.x > transform.position.x)
        {
            transform.Rotate(0, 180, 0);
        }
        isMoving = true;
    }
}
