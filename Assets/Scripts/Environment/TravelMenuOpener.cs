using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelMenuOpener : Collidable
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player _))
        {
            GameManager.Instance.travelMenuAnimator.SetTrigger("show");
        }
    }
}
