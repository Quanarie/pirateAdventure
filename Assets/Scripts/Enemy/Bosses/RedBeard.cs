using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBeard : Enemy
{
    protected override void Death()
    {
        GameManager.Instance.GrantXp(xpValue);
        GameManager.Instance.ShowText("+ " + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1f);

        QuestManager.Instance.enemyKilled = nameForQuest;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        boxCollider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Default");

        enabled = false;
    }
}
