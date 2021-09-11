using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerBlocker : MonoBehaviour
{
    public int questToBlock;

    public QuestTrigger questTrigger;

    private void Start()
    {
        questTrigger = GetComponent<QuestTrigger>();
        questTrigger.enabled = false;
    }
    private void Update()
    {
        if (QuestManager.Instance.questCompleted[questToBlock - 1])
        {
            questTrigger.enabled = true;
        }
    }
}
