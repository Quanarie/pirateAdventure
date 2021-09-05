using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    
    public QuestObject[] quests;
    public bool[] questCompleted;
    public bool isQuestTaken;

    [HideInInspector] public string itemCollected;
    [HideInInspector] public string enemyKilled;

    private void Start()
    {
        Instance = this;
    }

    public int GetCurrentMainQuest()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            if (!quests[i].isSideQuest && !questCompleted[i])
            {
                return i;
            }
        }

        return quests.Length;
    }

    public void SetCurrentMainQuest(int questNumber)
    {
        questCompleted = new bool[quests.Length];

        for (int i = 0; i < questNumber; i++)
        {
            if (!quests[i].isSideQuest)
            {
                questCompleted[i] = true;
            }
        }
    }
}
