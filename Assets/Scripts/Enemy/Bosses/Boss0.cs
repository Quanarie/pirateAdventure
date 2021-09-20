using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss0 : Enemy
{
    public float helperSpeed = 2.5f;
    public float radius = 0.25f;
    public Transform helper;

    protected override void Start()
    {
        base.Start();

        helper.gameObject.SetActive(false);
    }

    protected override void Death()
    {
        helper.gameObject.SetActive(true);
        helper.SetParent(null);

        Destroy(gameObject);

        GameManager.Instance.GrantXp(xpValue);
        GameManager.Instance.ShowText("+ " + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1f);

        QuestManager.Instance.enemyKilled = nameForQuest;

        
    }
}