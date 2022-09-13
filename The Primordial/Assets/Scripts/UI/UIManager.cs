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

    public Text coinCount;

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

    }
}
