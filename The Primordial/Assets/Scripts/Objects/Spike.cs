using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public int scene;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if(otherObj.tag == "Player")
        {
            Player player = otherObj.GetComponent<Player>();

            if(player != null)
            {
                player.DamageBySpikes();
                animator.SetTrigger("FadeTrigger");
            }
        }
    }

    public void OnFade()
    {
        SceneManager.LoadScene(scene);
    }
}
