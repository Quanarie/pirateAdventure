using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuest : QuestObject
{
    public string targetItem;

    private void Update()
    {
        if (targetItem == QuestManager.Instance.itemCollected)
        {
            QuestManager.Instance.itemCollected = null;

            EndQuest();
        }
    }
}
