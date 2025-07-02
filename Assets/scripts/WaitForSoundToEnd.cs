using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSoundToEnd : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на AudioSource

    void Start()
    {
        StartCoroutine(WaitForMusicToEnd());
    }

    IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying); // Ждём пока играет музыка
        OnMusicEnd(); // Вызываем метод после завершения
    }

    void OnMusicEnd()
    {
        Debug.Log("Музыка закончилась! Запускаем действие.");
        GameManager.Instance.EnemyKilled();
    }
}
