using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceRange : AIDecision
{
    public bool playerHasEntered = false;
    public bool playerInSight;
    public float sightRange;
    public LayerMask whatisPlayer;
    public Transform player;
    public Collider[] playerCollider = new Collider[1];


    public override bool Decide()
    {
        return playerHasEntered;
    }

    private void Update()
    {
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, sightRange, playerCollider, whatisPlayer);
        if (numColliders2 == 1)
        {
            player = playerCollider[0].transform;
        }
        else
        {
            player = null;
            playerHasEntered = false;
        }
        if (Vector3.Distance(player.transform.position,this.transform.position) < 4)
        {
            playerHasEntered = true;
        }
        if (Vector3.Distance(player.transform.position, this.transform.position) > 15)
        {
            playerHasEntered = false;
        }

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        playerHasEntered = false;
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
