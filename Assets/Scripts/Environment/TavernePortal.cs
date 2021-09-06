using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernePortal : Portal
{
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            GameManager.Instance.SaveState();

            SceneManager.LoadScene(GameManager.Instance.LastSceneName);
        }
    }
}