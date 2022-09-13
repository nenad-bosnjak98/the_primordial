using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int onlyOnce = 0;
    public DialogueTrigger trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true && onlyOnce == 0)
        {
            trigger.StartDialogue();
            onlyOnce++;
        }
        else
        {
            return;
        }
    }
}
