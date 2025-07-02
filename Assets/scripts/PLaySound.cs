using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaySound : MonoBehaviour
{
    public AudioSource audioSource;  // Ссылка на объект с AudioSource
    public AudioClip soundClip;     // Аудиофайл для проигрывания

    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);  // Проигрываем звук
        }
    }
}
