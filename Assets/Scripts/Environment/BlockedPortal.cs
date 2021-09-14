using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockedPortal : Portal
{
    [SerializeField] private int afterQuestNumber;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            if (QuestManager.Instance.questCompleted[afterQuestNumber])
            {
                GameManager.Instance.SaveState();

                GameManager.Instance.LastSceneName = SceneManager.GetActiveScene().name;

                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
