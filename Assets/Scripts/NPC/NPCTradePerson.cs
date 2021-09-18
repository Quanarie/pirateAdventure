using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTradePerson : NPCTextPerson
{
    [SerializeField] private int price;
    [SerializeField] private string[] newText;

    protected override void ActivateTradeOffer()
    {
        GameManager.Instance.tradeOffer.gameObject.SetActive(true);
        GameManager.Instance.tradeOffer.price = price;
        GameManager.Instance.priceText.text = price.ToString();
    }

    protected override void Update()
    {
        base.Update();
        if (GameManager.Instance.tradeOffer.isAccepted)
        {
            message = newText;
        }
    }
}