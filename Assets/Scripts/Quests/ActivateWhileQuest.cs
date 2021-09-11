using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhileQuest : MonoBehaviour
{
    [SerializeField] private int whileQuestNumber;
    [SerializeField] private GameObject toActivate;

    private void Start()
    {
        toActivate.SetActive(false);
    }

    private void Update()
    {
        if (QuestManager.Instance.quests[whileQuestNumber].isActiveAndEnabled)
        {
            toActivate.SetActive(true);
        }
    }
}
