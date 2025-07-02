using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public enum EnergyType { Type1, Type2 }
    public EnergyType energyType;
    public int energyAmount = 1; // ������� ������� ���������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���� �������� ������
        {
            EnergyPlayer playerEnergy = other.GetComponent<EnergyPlayer>();
            if (playerEnergy != null)
            {
                if (energyType == EnergyType.Type1)
                    playerEnergy.AddEnergy1(energyAmount);
                else
                    playerEnergy.AddEnergy2(energyAmount);
            }

            Destroy(gameObject); // ���������� �������� ����� �����
        }
    }
}
