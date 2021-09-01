using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLenght = 1f;
    public float chaseLenght = 5f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.Instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(playerTransform.position, startingPosition);
        if (distance < chaseLenght)
        {
            if (distance < triggerLenght)
            {
                chasing = true;
            }

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingWithPlayer = false;

        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].TryGetComponent(out Player _))
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);

        GameManager.Instance.GrantXp(xpValue);
        GameManager.Instance.ShowText("+ " + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1f);
    }
}
