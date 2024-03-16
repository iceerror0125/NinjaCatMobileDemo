using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip bg;
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
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBG()
    {
        audioSource.clip = bg;
        audioSource.Play();
    }
    public void StopBG()
    {
        audioSource.Stop();
    }

}
