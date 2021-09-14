using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCaptain : Enemy
{
    protected override void Death()
    {
        base.Death();

        SceneManager.LoadScene("MainScene");
        GameManager.Instance.ShowText("Congrats! You returned your ship! ^_^", 30, Color.green, transform.position, Vector3.up * 40, 5f);
    }
}
