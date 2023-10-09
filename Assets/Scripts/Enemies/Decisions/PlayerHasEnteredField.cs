using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerHasEnteredField : AIDecision
{
    public bool playerHasEntered = false;
    public bool playerinSight;
    public float sightRange;
    public LayerMask whatisPlayer;

    public override bool Decide()
    {
        return playerHasEntered;
    }

    private void Update()
    {
        playerinSight = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        if (playerinSight)
        {
            playerHasEntered = true;
        }
        if (!playerinSight)
        {
            playerHasEntered = false;
        }
        
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        playerHasEntered = false;
    }


}
