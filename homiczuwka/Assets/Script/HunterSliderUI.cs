using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject EndUI;
    public Button backToStart;

    public GameObject demonHunterWin;
    public GameObject angelHunterWin;
    private void Start()
    {
        demonHunterSlider.value = 0;
        angelHunterSlider.value = 0;
        EndUI.SetActive(false);
        angelHunterHP = 3;
        demonHunterHP = 3;
        DecreaseHunterHPUI(angelHunterHP, (int)ObjectType.HunterType.angelHunter);
        DecreaseHunterHPUI(demonHunterHP, (int)ObjectType.HunterType.demonHunter);

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

    public void HunterIsHit(int hunterType)
    {
        if (hunterType == (int)ObjectType.HunterType.demonHunter)
        {
            demonHunterHP--;
            DecreaseHunterHPUI(demonHunterHP, (int)ObjectType.HunterType.demonHunter);
            if (demonHunterHP <= 0)
            {
                GameIsOver((int)ObjectType.HunterType.angelHunter);
            }
        }
        else if (hunterType == (int)ObjectType.HunterType.angelHunter)
        {
            angelHunterHP--;
            DecreaseHunterHPUI(angelHunterHP, (int)ObjectType.HunterType.angelHunter);
            if (angelHunterHP <= 0)
            {
                GameIsOver((int)ObjectType.HunterType.demonHunter);
            }
        }
        else
        {
            Debug.LogAssertion("=========illegal import========");
        }
    }

    public void DecreaseHunterHPUI(int remnantHP, int hunterType = 0)
    {
        if (hunterType == (int)ObjectType.HunterType.angelHunter)
        {
            if (remnantHP == 3)
            {
                angelHunterHP1.SetActive(true);
                angelHunterHP2.SetActive(true);
                angelHunterHP3.SetActive(true);
            }
            else if (remnantHP == 2)
            {
                angelHunterHP1.SetActive(true);
                angelHunterHP2.SetActive(true);
                angelHunterHP3.SetActive(false);
            }
            else if (remnantHP == 1)
            {
                angelHunterHP1.SetActive(true);
                angelHunterHP2.SetActive(false);
                angelHunterHP3.SetActive(false);
            }
            else if (remnantHP == 0)
            {
                angelHunterHP1.SetActive(false);
                angelHunterHP2.SetActive(false);
                angelHunterHP3.SetActive(false);
                GameIsOver(-1 * (int)ObjectType.HunterType.angelHunter);
            }
            else
            {
                Debug.LogAssertion("=========illegal import========");
            }
        }
        else if (hunterType == (int)ObjectType.HunterType.demonHunter)
        {
            if (remnantHP == 3)
            {
                demonHunterHP1.SetActive(true);
                demonHunterHP2.SetActive(true);
                demonHunterHP3.SetActive(true);
            }
            else if (remnantHP == 2)
            {
                demonHunterHP1.SetActive(true);
                demonHunterHP2.SetActive(true);
                demonHunterHP3.SetActive(false);
            }
            else if (remnantHP == 1)
            {
                demonHunterHP1.SetActive(true);
                demonHunterHP2.SetActive(false);
                demonHunterHP3.SetActive(false);
            }
            else if (remnantHP == 0)
            {
                demonHunterHP1.SetActive(false);
                demonHunterHP2.SetActive(false);
                demonHunterHP3.SetActive(false);
                GameIsOver(-1 * (int)ObjectType.HunterType.demonHunter);
            }
            else
            {
                Debug.LogAssertion("=========illegal import========");
            }
        }
        else
        {
            Debug.LogAssertion("=========illegal import========");
        }

    }

    public void GameIsOver(int winnerType = 0)
    {
        Time.timeScale = 0;
        EndUI.SetActive(true);
        if (winnerType == (int)(ObjectType.HunterType.angelHunter))
        {
            demonHunterWin.SetActive(false);
            angelHunterWin.SetActive(true);
        }
        else if (winnerType == (int)(ObjectType.HunterType.demonHunter))
        {
            demonHunterWin.SetActive(true);
            angelHunterWin.SetActive(false);
        }
        else 
        {
            Debug.LogAssertion("=========illegal import========");
        }
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
