using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Client_Manager : MonoBehaviour
{

    [Header("Client List ")]
    public List<GameObject> clientList;

    [Header("Clients NavMesh")]
    public List<NavMeshAgent> clientNMA;

    [Header("Clients Positions")]
    public Transform enterStage;
    public Transform exitStage;
    public GameObject currentClient;
    public NavMeshAgent currentNMA;
    public bool isonTray;
    public Animator currentAnimator;
    public int ongoingClients = 0;

    private void Start()
    {
        currentClient = clientList[0];
        currentNMA = clientNMA[0];
    }

    void Update()
    {
        currentAnimator = currentClient.GetComponent<Animator>();
        if (!isonTray)
        {
            currentNMA.SetDestination(enterStage.position);
            if(Vector3.Distance(currentClient.transform.position,enterStage.position) <2)
            {
                isonTray = true;
            }
            
        }
        if (isonTray)
        {
            currentAnimator.SetBool("isStanding", true);
        }
        
        if(currentClient.GetComponent<clientOrder>().orderFinished == true)
        {
            currentAnimator.SetBool("isStanding", false);
            currentNMA.SetDestination(exitStage.position);
            if (Vector3.Distance(currentClient.transform.position, exitStage.position) < 2)
            {
                currentClient.SetActive(false);
                isonTray = false;
                if (ongoingClients < 1)
                {
                    ongoingClients++;
                    currentClient = clientList[ongoingClients];
                    currentNMA = clientNMA[ongoingClients];
                }

                
            }
            
        }



        
    }





}
