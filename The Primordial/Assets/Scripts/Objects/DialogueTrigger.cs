using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        DialogueManager.Instance.OpenConversation(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int actorID;
    public string message;
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
