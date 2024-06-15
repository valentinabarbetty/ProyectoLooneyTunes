using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip walk;
    public AudioClip jungle;  // Sonido de fondo
    private AudioSource audioSource;
    private AudioSource backgroundSource;  // Nuevo AudioSource para el sonido de fondo

    void Start()
    {
        // AudioSource para efectos de sonido (como caminar)
        audioSource = gameObject.AddComponent<AudioSource>();

        // AudioSource para el sonido de fondo
        backgroundSource = gameObject.AddComponent<AudioSource>();
        backgroundSource.clip = jungle;
        backgroundSource.loop = true;
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

    public void PlayBackgroundSound()
    {
        if (!backgroundSource.isPlaying)
        {
            backgroundSource.Play();
        }
    }
}
