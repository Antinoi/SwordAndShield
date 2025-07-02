using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPlayer : MonoBehaviour
{
    public int maxEnergy1 = 5;
    public int maxEnergy2 = 5;
    private int currentSwordEnergy;
    private int currentShieldEnergy;

    public Ultimates ultimates;

    public Slider SwordenergyBar1; // ������� ��� 1-� �������
    public Slider ShieldenergyBar2; // ������� ��� 2-� �������

    public Image? SwordenergyFill1; // ����������� ������� 1-� �����
    public Image? ShielenergyFill2; // ����������� ������� 2-� �����
    public Color normalColor1;
    public Color normalColor2;
    public Color glowColor = Color.yellow;  // ���� �������� ��� ���������

    void Start()
    {
        if(SwordenergyFill1 != null)
            normalColor1 = SwordenergyFill1.color;

        if (ShielenergyFill2 != null)
            normalColor2 = ShielenergyFill2.color;
        currentSwordEnergy = 0;
        currentShieldEnergy = 0;
        UpdateEnergyBars();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentSwordEnergy == maxEnergy1)
        {
            UseUltimate1();
        }
        if (Input.GetKeyDown(KeyCode.E) && currentShieldEnergy == maxEnergy2)
        {
            UseUltimate2();
        }
    }

    public void AddEnergy1(int amount)
    {
        if (currentSwordEnergy < maxEnergy1)
            currentSwordEnergy += amount;
        UpdateEnergyBars();
    }

    public void AddEnergy2(int amount)
    {
       if (currentShieldEnergy < maxEnergy2)
        {
            currentShieldEnergy += amount;
        }
        
        
        UpdateEnergyBars();
    }

    void UpdateEnergyBars()
    {
        
        if (SwordenergyBar1 != null)
        {
            SwordenergyBar1.value = (float)currentSwordEnergy;
           
        }
            

        if (ShieldenergyBar2 != null)
            ShieldenergyBar2.value = (float)currentShieldEnergy;


        // ������������ �����, ���� ������� ������������
        if (SwordenergyFill1 != null)
            SwordenergyFill1.color = (currentSwordEnergy == maxEnergy1) ? glowColor : normalColor1;

        if (ShielenergyFill2 != null)
            ShielenergyFill2.color = (currentShieldEnergy == maxEnergy2) ? glowColor : normalColor2;

      
    }



    void UseUltimate1()
    {
        
        ultimates.SwordU1();
        currentSwordEnergy = 0;
        UpdateEnergyBars();
    }

    void UseUltimate2()
    {
      
        ultimates.ShieldU2();
        currentShieldEnergy = 0;
        UpdateEnergyBars();
    }
}
