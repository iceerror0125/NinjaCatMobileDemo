using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopObject : MonoBehaviour
{
    private Vector2 originalPosition;
    [SerializeField] private float YLimit;
    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < YLimit)
        {
            transform.position = originalPosition;
        }
    }
}
