using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandShower : MonoBehaviour
{
    public Text text;
    public string info;

    private float distance;

    private void Start()
    {
        distance = GetComponent<IslandTeleport>().distance;
    }

    private void Update()
    {
        if (Vector3.Distance(Input.mousePosition, transform.position) <= distance)
        {
            text.enabled = true;
            text.text = info;
        }
        else
        {
            text.text = "";
        }
    }
}
