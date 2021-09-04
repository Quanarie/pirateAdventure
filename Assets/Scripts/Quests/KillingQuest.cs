using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingQuest : QuestObject
{
    public string targetEnemy;
    public int enemiesToKill;

    private int enemyKilled;

    private void Update()
    {
        if (QuestManager.Instance.enemyKilled == targetEnemy)
        {
            QuestManager.Instance.enemyKilled = null;

            enemyKilled++;
            if (enemyKilled >= enemiesToKill)
            {
                EndQuest();
            }
        }
    }
}
