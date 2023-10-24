using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : AIAction
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public Animator enemyAnimator;


    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();

    }

    public override void PerformAction()
    {
        enemy.SetDestination(transform.position);
        enemyAnimator.SetBool("isWalking", true);

        transform.LookAt(player);
        Invoke(nameof(resetAction), timeBetweenAttacks);
    }

    private void resetAction()
    {
        alreadyAttacked = false;
        enemyAnimator.SetBool("isWalking", false);
    }

}
