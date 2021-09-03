using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    public string[] message;

    private int messageNumber = 0;
    private float cooldown = 5f;
    private float lastMessage;

    private bool isBoxActive;

    protected override void Start()
    {
        base.Start();
        lastMessage = -cooldown;
    }

    protected override void Update()
    {
        base.Update();
        if (isBoxActive && Input.GetKeyDown(KeyCode.Tab))
        {
            if (messageNumber >= message.Length)
            {
                messageNumber = 0;

                isBoxActive = false;
                GameManager.Instance.dialogueBox.SetActive(false);
            }
            else
            {
                GameManager.Instance.dialogueText.text = message[messageNumber];
                messageNumber++;

                lastMessage = Time.time;
            }
        }
    }

    protected override void OnCollide(Collider2D collider)
    {
        if (Time.time - lastMessage > cooldown && messageNumber == 0)
        {
            GameManager.Instance.dialogueBox.SetActive(true);
            GameManager.Instance.dialogueText.text = message[0];
            messageNumber++;

            isBoxActive = true;

            lastMessage = Time.time;
        }
    }
}
