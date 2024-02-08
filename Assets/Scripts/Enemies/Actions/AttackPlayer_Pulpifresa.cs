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

    [Header("PulpiAttack")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    
    public Vector3 offset;


    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
        

    }

    public override void PerformAction()
    {
        enemy.SetDestination(this.transform.position);
        transform.LookAt(player);
        
        //isDizzy = true;

        
        
        


        

        //dashDirection.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        



    }

    IEnumerator dizzyState()
    {
        Debug.Log("pulpifresa is dizzy ! ");
        yield return new WaitForSeconds(7);
        Debug.Log("Its not dizzy anymore");
    }


}
