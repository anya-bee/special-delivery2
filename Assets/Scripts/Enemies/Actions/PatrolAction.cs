using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : AIAction
{
    

    public NavMeshAgent enemy;
    public LayerMask whatisground, whatisplayer;

    public Vector3 walkPointTransform;
    public bool walkPointSet;
    public float walkpointrange;
    public float Timer ;

    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<NavMeshAgent>();
        
    }

    public override void PerformAction()
    {
        Patrol();
    }

    public void Patrol()
    {
        if (!walkPointSet)
        {
            
                searchWalkPoint();
            
            
        }

        if (walkPointSet)
            enemy.SetDestination(walkPointTransform);

        Vector3 distanceToWalkPoint = transform.position - walkPointTransform;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {

                walkPointSet = false;

        }
           

    }

    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(-walkpointrange, walkpointrange);
        walkPointTransform = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z);

        if (Physics.Raycast(walkPointTransform, -transform.up, 2f, whatisground))
        {

            walkPointSet = true;
        }
    
    }

}
