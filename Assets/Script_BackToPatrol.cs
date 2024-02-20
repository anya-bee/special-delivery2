using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.AI;

public class Script_BackToPatrol : AIAction
{
    public NavMeshAgent enemy;
    Vector3 originalPosition;
    bool onway=false;
    protected override void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
        
    }

    public override void PerformAction()
    {
        
        if (Vector3.Distance(transform.position, originalPosition) > 1f)
        {
            enemy.SetDestination(originalPosition);
            onway= true;
        }
    }
}
