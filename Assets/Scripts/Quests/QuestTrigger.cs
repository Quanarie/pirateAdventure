using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public int questNumber;
    public bool startQuest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            if (!QuestManager.Instance.questCompleted[questNumber])
            {
                if (startQuest && !QuestManager.Instance.quests[questNumber].gameObject.activeSelf)
                {
                    QuestManager.Instance.quests[questNumber].gameObject.SetActive(true);
                    QuestManager.Instance.quests[questNumber].StartQuest();
                }
                else if (!startQuest && QuestManager.Instance.quests[questNumber].gameObject.activeSelf)
                {
                    QuestManager.Instance.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
