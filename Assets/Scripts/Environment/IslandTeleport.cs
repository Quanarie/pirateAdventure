using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IslandTeleport : MonoBehaviour
{
    public string sceneName;
    public float distance;

    private float colorA = 0.2f;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (Vector3.Distance(Input.mousePosition, transform.position) <= distance)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, colorA);
            image.color = new Color(image.color.r, image.color.g, image.color.b, colorA);
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.travelMenuAnimator.SetTrigger("hide");

                QuestManager.Instance.isQuestTaken = false;

                GameManager.Instance.SaveState();
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }
}
