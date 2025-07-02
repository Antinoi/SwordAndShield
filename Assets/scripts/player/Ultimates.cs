using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimates : MonoBehaviour
{
    public GameObject shield;
    public GameObject energyBeam;
    public PlayerLife playerLife;

    public Animator uiAnimator; // Аниматор UI

    public float beamDuration = 2f; // Длительность луча
    public float shieldDuration = 4f;

    public bool isSwordUltimateActive = false;
    public bool isShieldUltimateActive = false;

    private void Start()
    {
        energyBeam.SetActive(false);
        shield.SetActive(false);
    }

    public void SwordU1()
    {
        if (!isSwordUltimateActive && !isShieldUltimateActive)  // Проверяем, не активна ли другая ульта
        {
            isSwordUltimateActive = true;  // Активируем флаг, что ульта активирована
            uiAnimator.SetTrigger("SwordTrigger"); // Запускаем анимацию
            StartCoroutine(WaitForAnimation()); // Ждём завершения анимации

            if (energyBeam != null)
            {
                energyBeam.SetActive(true); // Включаем луч
                Invoke(nameof(DeactivateBeam), beamDuration); // Отключаем через beamDuration
            }
        }
    }

    public void ShieldU2()
    {
        if (!isSwordUltimateActive && !isShieldUltimateActive)  // Проверяем, не активна ли другая ульта
        {
            isShieldUltimateActive = true;  // Активируем флаг, что ульта активирована
            uiAnimator.SetTrigger("ShieldTrigger"); // Запускаем анимацию
            StartCoroutine(WaitForAnimation()); // Ждём завершения анимации

            shield.SetActive(true);
            playerLife.Heal(2);

            Invoke(nameof(DeactivateShield), shieldDuration);
        }
    }

    private void DeactivateBeam()
    {
        if (energyBeam != null)
        {
            energyBeam.SetActive(false);
        }
        isSwordUltimateActive = false;  // Деактивируем флаг
    }

    private void DeactivateShield()
    {
        shield.SetActive(false);
        isShieldUltimateActive = false;  // Деактивируем флаг
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; // Даем кадру обновиться
        AnimatorStateInfo stateInfo = uiAnimator.GetCurrentAnimatorStateInfo(0);

        // Ждём, пока анимация будет идти
        yield return new WaitUntil(() => stateInfo.normalizedTime >= 1f);
    }
}
