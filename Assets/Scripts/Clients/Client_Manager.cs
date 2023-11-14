using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// This code is a Client Manager, which updates clients and their nav mesh, so they always go to the same tray to get their order. When a client finishes, 
// the next goes and so on.

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
    public int count;

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
                
                isonTray = false;
                if (ongoingClients < (clientList.Count))
                {
                    
                    currentClient.SetActive(false);
                    ongoingClients++;
                    currentClient = clientList[ongoingClients];
                    currentNMA = clientNMA[ongoingClients];

                }
                if( currentClient.GetComponent<clientOrder>().lastClient == true )
                {
                    currentClient.SetActive(true);
                    isonTray = true;
                    currentClient = clientList[ongoingClients];
                    currentNMA = clientNMA[ongoingClients];
                }

                
            }
            
        }



        
    }





}
