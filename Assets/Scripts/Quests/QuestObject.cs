using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;
    public string startText;
    public string endText;
    public bool isSideQuest;

    [SerializeField] protected int xpReward;
    [SerializeField] protected int pesosReward;

    public virtual void StartQuest()
    {
        GameManager.Instance.ShowText(startText, 30, Color.black, GameManager.Instance.player.transform.position, Vector3.zero, 5f);
    }

    public void EndQuest()
    {
        if (pesosReward != 0)
        {
            GameManager.Instance.GrantPesos(pesosReward);
        }

        GameManager.Instance.GrantXp(xpReward);

        GameManager.Instance.ShowText(endText, 30, Color.black, GameManager.Instance.player.transform.position, Vector3.zero, 5f);

        QuestManager.Instance.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}