using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public void DestroyText()
    {
        Destroy(transform.parent.gameObject);
    }
}
