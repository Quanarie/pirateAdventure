using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;
    public string startText;
    public string endText;
    public bool isSideQuest;

    [SerializeField] private int xpReward;

    public void StartQuest()
    {
        GameManager.Instance.ShowText(startText, 30, Color.black, GameManager.Instance.player.transform.position, Vector3.zero, 5f);
    }

    public void EndQuest()
    {
        GameManager.Instance.GrantXp(xpReward);

        GameManager.Instance.ShowText("+ " + xpReward + " xp", 30, Color.red, GameManager.Instance.player.transform.position, Vector3.up * 40, 1f);
        GameManager.Instance.ShowText(endText, 30, Color.black, GameManager.Instance.player.transform.position, Vector3.zero, 5f);

        QuestManager.Instance.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}