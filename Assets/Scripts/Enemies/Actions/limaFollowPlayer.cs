using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class limaFollowPlayer : AIAction
{

    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public Animator enemyAnimator;

    [Header("Timer")]
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
        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            GetComponent<lima_AcidSplash>().shootAcid();

            alreadyAttacked = true;
            Invoke(nameof(resetAction), timeBetweenAttacks);
        }



    }

    private void resetAction()
    {
        alreadyAttacked = false;

    }

    //enemyAnimator.SetBool("attack", false);

}
