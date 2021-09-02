using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    public string message;

    private float cooldown = 5f;
    private float lastMessage;

    protected override void Start()
    {
        base.Start();
        lastMessage = -cooldown;
    }

    protected override void OnCollide(Collider2D collider)
    {
        if (Time.time - lastMessage > cooldown)
        {
            GameManager.Instance.ShowText(message, 25, Color.white, transform.position + GetComponent<BoxCollider2D>().bounds.extents, Vector3.zero, 4f);
            lastMessage = Time.time;
        }
    }
}
