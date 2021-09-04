using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipShopNPC : MonoBehaviour
{
    public int[] prices;
    
    public Image currentShip;
    public Image nextShip;
    public SpriteRenderer ship;
    public Sprite[] shipSprites;
    public Text buyShipText;

    public Animator animator;

    private void Start()
    {
        UpdateMenu();
    }

    public void UpdateMenu()
    {
        int shipLevel = GameManager.Instance.shipLevel;

        if (shipLevel == shipSprites.Length - 1)
        {
            currentShip.sprite = shipSprites[shipLevel];
            nextShip.sprite = shipSprites[shipLevel];

            buyShipText.text = "MAX";
        }
        else
        {
            currentShip.sprite = shipSprites[shipLevel];
            nextShip.sprite = shipSprites[shipLevel + 1];

            buyShipText.text = prices[shipLevel + 1].ToString();
        }
        ship.sprite = shipSprites[shipLevel];
    }

    public void BuyButtonClicked()
    {
        int shipLevel = GameManager.Instance.shipLevel;

        if (shipLevel != shipSprites.Length - 1)
        {
            if (GameManager.Instance.pesos - prices[shipLevel + 1] >= 0)
            {
                GameManager.Instance.pesos -= prices[shipLevel + 1];
                GameManager.Instance.shipLevel++;
                UpdateMenu();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            animator.SetTrigger("show");
        }
    }
}
