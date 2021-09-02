using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss0 : Enemy
{
    public float helperSpeed = 2.5f;
    public float radius = 0.25f;
    public Transform helper;

    private void Update()
    {
        helper.position = transform.position + new Vector3(-Mathf.Cos(Time.time * helperSpeed) * radius, Mathf.Sin(Time.time * helperSpeed) * radius, 0);
    }
}