using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelMenuOpener : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            GameManager.Instance.travelMenuAnimator.SetTrigger("show");
        }
    }
}
