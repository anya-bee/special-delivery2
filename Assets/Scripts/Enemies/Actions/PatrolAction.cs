using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : AIAction
{
    

    public NavMeshAgent enemy;
    public LayerMask whatisground, whatisplayer;

    public Vector3 walkPointTransform;
    Transform original;
    public bool walkPointSet;
    
    public float Timer ;

    [Header ("Movement Range")]
    public float safedistance;
    public float walkpointrange;

    
    bool direccion = true;
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<NavMeshAgent>();
        original = transform;
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
        float randomx = Random.Range(safedistance, walkpointrange + safedistance);
        
        if (direccion)
        {
            walkPointTransform = new Vector3(original.position.x + randomx, original.position.y, original.position.z);
            direccion = false;
        }
        else
        {
            walkPointTransform = new Vector3(original.position.x - randomx, original.position.y, original.position.z);
            direccion = true;
        }
      
        

        if (Physics.Raycast(walkPointTransform, -transform.up, 2f, whatisground))
        {

            walkPointSet = true;
        }
    
    }

}
