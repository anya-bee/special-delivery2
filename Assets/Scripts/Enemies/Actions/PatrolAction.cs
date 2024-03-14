using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : AIAction
{
    

    public NavMeshAgent enemy;
    public LayerMask whatisground, whatisplayer;

    public Vector3 walkPointTransform;
    Vector3 original;
    public bool walkPointSet;
    public float originalSpeed;
    public float Timer ;
    private bool limaOut;

    [Header ("Movement Range")]
    public float safedistance;
    public float walkpointrange;

    
    bool direccion = true;
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<NavMeshAgent>();
        original = transform.position;
        walkPointTransform= transform.position;
        originalSpeed = enemy.speed;
    }

    public override void PerformAction()
    {
        Patrol();
    }

    public void Patrol()
    {
        
        if (GetComponent<EnemyHealth>().enemyString == "Lime_Fruit")
        {
            GetComponent<lima_AcidSplash>().now = false;
        }
        enemy.speed = originalSpeed;
        if (Vector3.Distance(transform.position,walkPointTransform) < 1f)
        {
            
            searchWalkPoint();
            
        }
        enemy.SetDestination(walkPointTransform);

    }

    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(safedistance, walkpointrange + safedistance);
        
        if (direccion)
        {
            walkPointTransform = new Vector3(original.x + randomx, original.y, original.z);
            
            direccion = false;
        }
        else
        {
            walkPointTransform = new Vector3(original.x - randomx, original.y, original.z);
            direccion = true;
        }
      
        /*

        if (Physics.Raycast(walkPointTransform, -transform.up, 2f, whatisground))
        {

            walkPointSet = true;
        }*/
    
    }

}
