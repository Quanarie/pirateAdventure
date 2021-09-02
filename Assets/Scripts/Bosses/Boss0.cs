using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss0 : Enemy
{
    public float helperSpeed = 2.5f;
    public float radius = 0.25f;
    public Transform helper;
    public Transform parent;

    protected override void Start()
    {
        base.Start();

        helper.gameObject.SetActive(false);
    }

    private void Update()
    {
        helper.position = transform.position + new Vector3(-Mathf.Cos(Time.time * helperSpeed) * radius, Mathf.Sin(Time.time * helperSpeed) * radius, 0);
    }

    protected override void Death()
    {
        helper.gameObject.SetActive(true);
        helper.SetParent(parent);

        Destroy(gameObject);

        GameManager.Instance.GrantXp(xpValue);
        GameManager.Instance.ShowText("+ " + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1f);
    }
}