using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string sceneName;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            GameManager.Instance.SaveState();
            SceneManager.LoadScene(sceneName);
        }
    }
}
