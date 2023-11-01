using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clientTestMovement : MonoBehaviour
{
    [Header("Client List ")]
    public GameObject clientList;

    [Header("Clients NavMesh")]
    public NavMeshAgent clientNMA;

    public Transform enterStage;

    private void Update()
    {
        clientNMA.SetDestination(enterStage.position);
    }


}
