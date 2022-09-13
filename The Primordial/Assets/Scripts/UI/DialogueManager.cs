using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                throw new UnityException();
            }
            return instance;
        }
    }

    public Image actorImage;
    public Text actorText;
    public Text messageText;
    public RectTransform backBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int active = 0;
    public static bool isActive = false;

    public void OpenConversation(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        active = 0;
        isActive = true;
        Debug.Log("Messages and actors!");
        DisplayMessageOnScreen();
        backBox.transform.localScale = Vector3.one;
    }

    void DisplayMessageOnScreen()
    {
        Message messageToDisplay = currentMessages[active];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorText.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        active++;
        if(active < currentMessages.Length)
        {
            DisplayMessageOnScreen();
        }
        else
        {
            Debug.Log("Conversation ended!");
            backBox.transform.localScale = Vector3.zero;
            isActive = false;
        }
    }
    
    void Start()
    {
        backBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
