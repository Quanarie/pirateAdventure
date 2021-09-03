using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    private float healCooldown = 3f;
    private float lastHeal;
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        lastHeal = -healCooldown;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (isAlive)
        {
            UpdateMotor(new Vector3(x, y, 0));

            if (x != 0 && y != 0)
            {
                animator.SetBool("move", true);
            }
            else if (x == 0 && y == 0)
            {
                animator.SetBool("move", false);
            }
        }
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.Instance.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
            return;

        base.ReceiveDamage(dmg);

        GameManager.Instance.OnHitpointChange();
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.Instance.deathMenuAnimator.SetTrigger("show");
    }

    public void Heal(int toHeal)
    {
        if (hitpoint != maxHitpoint && Time.time - lastHeal >= healCooldown)
        {
            if (hitpoint + toHeal <= maxHitpoint)
            {
                hitpoint += toHeal;
                GameManager.Instance.ShowText("+ " + toHeal + "hp", 20, Color.green, transform.position, Vector3.up * 40, 2f);

                lastHeal = Time.time;
            }
        }
    }

    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
