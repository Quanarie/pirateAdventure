using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite openedChest;
    public int pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = openedChest;
            GameManager.Instance.ShowText("+ " + pesosAmount + " pesos", 25, Color.green, transform.position, Vector3.up * 25, 1f);
        }
    }
}
