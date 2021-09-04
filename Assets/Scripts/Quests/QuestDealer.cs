using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDealer : MonoBehaviour
{
    private int questNumber;
    private QuestTrigger questTrigger;
    private BoxCollider2D bCollider;

    private void Start()
    {
        questTrigger = GetComponent<QuestTrigger>();
        questNumber = QuestManager.Instance.GetCurrentMainQuest();
        bCollider = GetComponent<BoxCollider2D>();

        if (questNumber == QuestManager.Instance.quests.Length)
        {
            bCollider.enabled = false;
        }
        else
        {
            questTrigger.questNumber = questNumber;
        }
    }
}
