using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;


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

    [Header("Take Away Clients")]
    public GameObject orderCheckedComponent;
    public float clientsTimer;
    public Image bar;
    private float antiTimer;
    public float timeRemainder;

    [Header("GameOver")]
    public TextMeshProUGUI completedLevel;
    public Image fadeToBlack;
    public Image gameOverBoard;
    public Button goToTravellBttn;

   

    private void Start()
    {
        currentClient = clientList[0];
        currentNMA = clientNMA[0];
        goToTravellBttn.gameObject.SetActive(false);
        gameOverBoard.gameObject.SetActive(false);
        fadeToBlack.gameObject.SetActive(false);
        completedLevel.gameObject.SetActive(false);

        

    }

    IEnumerator clientGoAway(float t)
    {
        yield return new WaitForSeconds(t);
        orderCheckedComponent.GetComponent<orderChecked>().orderFinished = true;

    }

    IEnumerator appearButton()
    {
        fadeToBlack.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        completedLevel.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameOverBoard.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1.5f);
        goToTravellBttn.gameObject.SetActive(true);
        gameOverBoard.GetComponent<starScoreDisplay>().callForStars();
        


    }

    void Update()
    {

        
        currentAnimator = currentClient.GetComponent<Animator>();
        if (!isonTray)
        {
            antiTimer = clientsTimer + timeRemainder;
            currentNMA.SetDestination(enterStage.position);
            if(Vector3.Distance(currentClient.transform.position,enterStage.position) <2)
            {
                isonTray = true;
                StartCoroutine(clientGoAway(clientsTimer));
            }
            
        }
        if (isonTray)
        {
            
            bar.fillAmount = (antiTimer -= Time.deltaTime) / (clientsTimer + timeRemainder ) ;
            currentAnimator.SetBool("isStanding", true);
        }
        
        if(currentClient.GetComponent<clientOrder>().orderFinished == true)
        {
            currentAnimator.SetBool("isStanding", false);
            
            currentNMA.SetDestination(exitStage.position);

            
            if(currentClient.GetComponent<clientOrder>().lastClient == true)
            {
                ongoingClients = clientList.Count;
                
                StartCoroutine(appearButton());
            }
            if (Vector3.Distance(currentClient.transform.position, exitStage.position) < 2 && currentClient.GetComponent<clientOrder>().lastClient == false)
            {
                
                isonTray = false;
                if (ongoingClients < (clientList.Count) )
                {
                    
                    currentClient.SetActive(false);
                    ongoingClients++;
                    currentClient = clientList[ongoingClients];
                    currentNMA = clientNMA[ongoingClients];
                    bar.fillAmount = 1;
                    antiTimer = clientsTimer + timeRemainder;

                }
                /*if(ongoingClients == clientList.Count)
                {
                    currentClient.SetActive(true);
                    ongoingClients = clientList.Count;

                }*/
               

            }
            


        }



        
    }
    







}
