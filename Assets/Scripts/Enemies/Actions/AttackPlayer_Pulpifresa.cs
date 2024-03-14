using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer_Pulpifresa : AIAction
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public Animator enemyAnimator;
    public int dmg = 0;
    public Transform knockBack;

    [Header("PulpiAttack")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public bool damaged = false;

    
    public Vector3 offset;


    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
        

    }

    public override void PerformAction()
    {
        
        enemy.SetDestination(transform.position);
        enemy.speed = 0;
        enemy.acceleration = 0;
        transform.LookAt(player);
        
        //isDizzy = true;

        
        if(damaged == true)
        {
            StartCoroutine(dizzyState());
        }
        


        

        //dashDirection.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        



    }

    IEnumerator dizzyState()
    {
        Debug.Log("pulpifresa is dizzy ! ");
        enemy.SetDestination(knockBack.position);
        yield return new WaitForSeconds(1);
        Debug.Log("Its not dizzy anymore");
        damaged = false;
    }


}
