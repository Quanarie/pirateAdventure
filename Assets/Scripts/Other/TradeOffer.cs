using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeOffer : MonoBehaviour
{
    [HideInInspector] public int price;
    [HideInInspector] public bool isAccepted = false;

    public void Accept()
    {
        if (GameManager.Instance.pesos - price < 0)
            return;
        GameManager.Instance.pesos -= price;
        GameManager.Instance.tradeOffer.gameObject.SetActive(false);
        isAccepted = true;
    }

    public void Decline()
    {
        GameManager.Instance.tradeOffer.gameObject.SetActive(false);
    }
}
