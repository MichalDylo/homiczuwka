using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HunterSliderUI : MonoBehaviour
{
    public Slider demonHunterSlider;
    public Slider angelHunterSlider;

    private void Start()
    {
        demonHunterSlider.value = 0;
        angelHunterSlider.value = 0;
    }

    public void DemonIsHunted(int hunterType = 0)
    {
        if (hunterType == (int)ObjectType.HunterType.angelHunter)
        {
            angelHunterSlider.value -= 0.1f;
        }
        else 
        {
            demonHunterSlider.value += 0.15f;
        }
        if (angelHunterSlider.value < 0)
        {
            angelHunterSlider.value = 0;
        }
    }

    public void AngelIsHunted(int hunterType = 0)
    {
        if (hunterType == (int)ObjectType.HunterType.angelHunter)
        {
            angelHunterSlider.value += 0.15f;
        }
        else
        {
            demonHunterSlider.value -= 0.1f;
        }

        if (demonHunterSlider.value < 0)
        {
            demonHunterSlider.value = 0;
        }
    }

}
