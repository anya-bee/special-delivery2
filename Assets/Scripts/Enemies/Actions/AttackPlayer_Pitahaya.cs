using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer_Pitahaya : AIAction
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public Animator enemyAnimator;
    public int dmg;


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
        GetComponent<Animator>().SetTrigger("explode");
        StartCoroutine(waitToDie());

        



    }


    IEnumerator waitToDie()
    {
        yield return new WaitForSeconds(1.1f);
        gameObject.GetComponent<EnemyHealth>().currentLifeAmount = 0;
        
    }

    IEnumerator waitToDie2()
    {
        yield return new WaitForSeconds(1.1f);
        gameObject.GetComponent<EnemyHealth>().currentLifeAmount = 0;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
    }
}
