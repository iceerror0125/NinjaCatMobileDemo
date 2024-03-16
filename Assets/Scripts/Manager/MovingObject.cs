using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;

    public void SetSpeed(float speed)
    {
        this.speed = speed; 
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
