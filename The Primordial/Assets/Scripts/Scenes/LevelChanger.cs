using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    private void OnTriggerEnter2D(Collider2D statue)
    {
        if(statue.tag == "Player")
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int index)
    {
        levelToLoad = index;
        animator.SetTrigger("FadeTrigger"); // Starts fade and calls animation event OnFade()
    }

    public void OnFade()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
