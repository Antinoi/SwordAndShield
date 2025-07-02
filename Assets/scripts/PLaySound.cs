using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaySound : MonoBehaviour
{
    public AudioSource audioSource;  // ������ �� ������ � AudioSource
    public AudioClip soundClip;     // ��������� ��� ������������

    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);  // ����������� ����
        }
    }
}
