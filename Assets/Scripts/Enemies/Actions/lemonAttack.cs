using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lemonAttack : AIAction
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public Animator enemyAnimator;
    public int dmg = 0;


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

            enemyAnimator.SetTrigger("attackTrigger");
            player.gameObject.GetComponent<PlayerHealth>().Damage(dmg);
            player.GetComponent<PlayerController>().stunnedState = true;

            alreadyAttacked = true;
            Invoke(nameof(resetAction), timeBetweenAttacks);
        }



    }

    private void resetAction()
    {
        alreadyAttacked = false;

    }

}