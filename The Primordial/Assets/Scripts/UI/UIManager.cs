using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                throw new UnityException();
            }
            return instance;
        }
    }

    private int index = 3;
    public Text coinCount;
    public Image[] healthBars;

    public void UpdateCoinCount(int count)
    {
        coinCount.text = "" + count; 
    }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLives(int life)
    {
        for(int i = 0; i < life; i++)
        {
            if(i == life * 0.75)
            {
                healthBars[index].enabled = false;
                index--;
                Debug.Log(index);
            }
        }
        if(life == 0)
        {
            healthBars[index].enabled = false;
        }
    }
}
