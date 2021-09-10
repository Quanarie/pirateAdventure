using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBlocker : MonoBehaviour
{
    [SerializeField] private int afterQuestNumber;
    
    [SerializeField] private string[] newDialogueText;
    private NPCTextPerson textScript;

    private void Start()
    {
        textScript = GetComponent<NPCTextPerson>();
        textScript.enabled = false;
    }

    private void Update()
    {
        if (QuestManager.Instance.questCompleted[afterQuestNumber])
        {
            textScript.enabled = true;
        }
        if (QuestManager.Instance.questCompleted[afterQuestNumber + 1])
        {
            textScript.message = newDialogueText;
        }
    }
}
