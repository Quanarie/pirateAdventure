using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : Mover
{
    public float walkTime;
    public float waitTime;

    private float walkCounter;
    private float waitCounter;

    private bool isWalking;

    private Vector3 walkDirection;

    private Animator animator;

    private Vector3 ChooseWalkDirection()
    {
        int rand = Random.Range(0, 4);
        if (rand == 0) return new Vector3(0f, 1f, 0f);
        else if (rand == 1) return new Vector3(1f, 0f, 0f);
        else if (rand == 2) return new Vector3(0f, -1f, 0f);
        else return new Vector3(-1f, 0f, 0f);
    }


    protected override void Start()
    {
        base.Start();

        walkCounter = Time.time;

        isWalking = true;
        walkDirection = ChooseWalkDirection();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isWalking)
        {
            if (Time.time - walkCounter < walkTime)
            {
                animator.SetBool("move", true);
                UpdateMotor(walkDirection);
            }
            else
            {
                waitCounter = Time.time;
                isWalking = false;
                animator.SetBool("move", false);
            }
        }
        else if (Time.time - waitCounter >= waitTime)
        {
            isWalking = true;
            walkCounter = Time.time;
            walkDirection = ChooseWalkDirection();
        }
    }
}
