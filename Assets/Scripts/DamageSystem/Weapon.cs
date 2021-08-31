using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7 };
    public float[] pushForce = {2f, 2.2f, 2.5f, 3f, 3.7f, 4.5f, 6f};

    public int weaponLevel = 0;

    private SpriteRenderer spriteRenderer;

    private Animator animator;
    private float cooldown = 0.5f;
    private float lastSwing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    private void Swing()
    {
        animator.SetTrigger("Swing");
    }

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Fighter")
        {
            if (collider.TryGetComponent(out Player _))
                return;

            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            collider.SendMessage("ReceiveDamage", dmg);
        }
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }

    public void SetLevelWeapon(int lvl)
    {
        weaponLevel = lvl;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }
}
