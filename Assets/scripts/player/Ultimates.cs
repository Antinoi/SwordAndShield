using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimates : MonoBehaviour
{
    public GameObject shield;
    public GameObject energyBeam;
    public PlayerLife playerLife;

    public Animator uiAnimator; // �������� UI

    public float beamDuration = 2f; // ������������ ����
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
        if (!isSwordUltimateActive && !isShieldUltimateActive)  // ���������, �� ������� �� ������ �����
        {
            isSwordUltimateActive = true;  // ���������� ����, ��� ����� ������������
            uiAnimator.SetTrigger("SwordTrigger"); // ��������� ��������
            StartCoroutine(WaitForAnimation()); // ��� ���������� ��������

            if (energyBeam != null)
            {
                energyBeam.SetActive(true); // �������� ���
                Invoke(nameof(DeactivateBeam), beamDuration); // ��������� ����� beamDuration
            }
        }
    }

    public void ShieldU2()
    {
        if (!isSwordUltimateActive && !isShieldUltimateActive)  // ���������, �� ������� �� ������ �����
        {
            isShieldUltimateActive = true;  // ���������� ����, ��� ����� ������������
            uiAnimator.SetTrigger("ShieldTrigger"); // ��������� ��������
            StartCoroutine(WaitForAnimation()); // ��� ���������� ��������

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
        isSwordUltimateActive = false;  // ������������ ����
    }

    private void DeactivateShield()
    {
        shield.SetActive(false);
        isShieldUltimateActive = false;  // ������������ ����
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; // ���� ����� ����������
        AnimatorStateInfo stateInfo = uiAnimator.GetCurrentAnimatorStateInfo(0);

        // ���, ���� �������� ����� ����
        yield return new WaitUntil(() => stateInfo.normalizedTime >= 1f);
    }
}
