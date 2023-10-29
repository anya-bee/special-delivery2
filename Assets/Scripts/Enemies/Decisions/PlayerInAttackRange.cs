using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerInAttackRange : AIDecision
{
    public bool playerHasEntered = false;
    public bool playerInSight;
    public float sightRange;
    public LayerMask whatisPlayer;


    public override bool Decide()
    {
        return playerHasEntered;
    }

    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        if (playerInSight)
        {
            playerHasEntered = true;
        }
        if (!playerInSight)
        {
            playerHasEntered = false;
        }

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        playerHasEntered = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
