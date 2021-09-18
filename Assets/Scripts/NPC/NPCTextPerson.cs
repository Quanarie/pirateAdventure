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

    private NPCMovement moveScript;
    private float xSpeedPlayer;
    private float ySpeedPlayer;

    protected override void Start()
    {
        base.Start();
        lastMessage = -cooldown;
        moveScript = GetComponent<NPCMovement>();
        xSpeedPlayer = GameManager.Instance.player.xSpeed;
        ySpeedPlayer = GameManager.Instance.player.ySpeed;
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
                if (moveScript != null)
                    moveScript.enabled = true;
                GameManager.Instance.player.xSpeed = xSpeedPlayer;
                GameManager.Instance.player.ySpeed = ySpeedPlayer;

                ActivateTradeOffer();
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
        if (collider.TryGetComponent(out Player _))
        {
            if (Time.time - lastMessage > cooldown && messageNumber == 0)
            {
                GameManager.Instance.dialogueBox.SetActive(true);
                GameManager.Instance.dialogueText.text = message[0];
                messageNumber++;

                if (moveScript != null)
                    moveScript.enabled = false;
                GameManager.Instance.player.xSpeed = 0f;
                GameManager.Instance.player.ySpeed = 0f;
                isBoxActive = true;

                lastMessage = Time.time;
            }
        }
    }

    protected virtual void ActivateTradeOffer()
    {

    }    
}
