using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip walk;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found.");
        }
    }

    public void PlayWalkSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = walk;
            audioSource.Play();
        }
    }

    public void StopWalkSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
