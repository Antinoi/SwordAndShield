using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSoundToEnd : MonoBehaviour
{
    public AudioSource audioSource; // ������ �� AudioSource

    void Start()
    {
        StartCoroutine(WaitForMusicToEnd());
    }

    IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying); // ��� ���� ������ ������
        OnMusicEnd(); // �������� ����� ����� ����������
    }

    void OnMusicEnd()
    {
        Debug.Log("������ �����������! ��������� ��������.");
        GameManager.Instance.EnemyKilled();
    }
}
