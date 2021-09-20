using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCaptain : Enemy
{
    protected override void Death()
    {
        base.Death();
        GameManager.Instance.shipLevel = GameManager.Instance.shipShop.shipSprites.Length - 1;
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.shipShop.UpdateMenu();
        GameManager.Instance.ShowText("Congrats! You returned your ship! ^_^", 30, Color.blue, transform.position, Vector3.up * 40, 5f);
    }
}
