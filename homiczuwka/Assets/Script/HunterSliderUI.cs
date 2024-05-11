using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HunterSliderUI : MonoBehaviour
{
    public Slider demonHunterSlider;
    public Slider angelHunterSlider;

    public int demonHunterHP = 3;
    public GameObject demonHunterHP1;
    public GameObject demonHunterHP2;
    public GameObject demonHunterHP3;

    public int angelHunterHP = 3;
    public GameObject angelHunterHP1;
    public GameObject angelHunterHP2;
    public GameObject angelHunterHP3;

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

    public void AngelHunterIsHit()
    {
        angelHunterHP--;
        if (angelHunterHP <= 0)
        {
            GameIsOver((int)ObjectType.HunterType.demonHunter);
        }
    }

    public void DemonHunterIsHit()
    {
        demonHunterHP--;
        if (demonHunterHP <= 0)
        {
            GameIsOver((int)ObjectType.HunterType.angelHunter);
        }    
    }

    public void GameIsOver(int winnerType = 0)
    { 
        
    }
}
