using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatQuest : QuestObject
{
    [SerializeField] private float timeExisting;
    [SerializeField] private int maxReward;
    private Slider slider;
    private float difficulty = 10f;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public override void StartQuest()
    {
        base.StartQuest();

        StartCoroutine(disableQuest());
    }

    private void Update()
    {
        slider.value -= Time.deltaTime;
        if (slider.value < 0) slider.value = 0;

        if (Input.GetMouseButtonDown(0)) slider.value += Time.deltaTime * difficulty;
    }

    public IEnumerator disableQuest()
    {
        yield return new WaitForSeconds(timeExisting);

        pesosReward = (int)((slider.value / slider.maxValue) * maxReward);

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
