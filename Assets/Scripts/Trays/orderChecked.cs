using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderChecked : MonoBehaviour
{

    // This code works for TRAYS, where orders are placed. Trays check the clients order and the order of the glass placed over it. 
    // in the end, it delivers point based on the smoothie. 10+ per each correct fruit

    [Header("Orders")]
    public List<string> glassOrder1;
    public List<string> clientOrder1;
    public int points = 0;
    public bool orderFinished = false;
    public bool clientEntered = false;

    [Header("Range Values")]

    public LayerMask glassLayer;
    public LayerMask clientLayer;
    public float radius;
    public bool glassIsOnTray = false;

    [Header("Client and Glass")]
    public GameObject Client;
    public GameObject Glass;
    public Collider[] clientHitColliders = new Collider[1];
    public Collider[] glassHitColliders = new Collider[1];

    [Header("Tutorial")]
    [SerializeField] bool isTutorial = false;
    [SerializeField] Script_ActionsTutorial actionActivate;

    private void Update()
    {
        
         
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, glassHitColliders, glassLayer);

        if (numColliders2 == 1 && glassIsOnTray)
        {
            Glass = glassHitColliders[0].gameObject;
            glassOrder1 = Glass.GetComponent<juiceGlass>().glassOrder;
        }

        

        if(clientEntered && Glass != null)
        {
            if (clientEntered == false)
            {
                StartCoroutine(destroyGlass(Glass));

                clientEntered = false;
                Glass = null;
                glassOrder1 = null;
            }
            checkOrder();
            
        }
        
        if(orderFinished == true)
        {
            orderFinished = false;
            StartCoroutine(destroyGlass(Glass));

            
            clientEntered = false;
            Glass = null;
            for (int i = 0; i < 3; i++)
            {
                glassOrder1[i] = null;


                

            }

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void takeClientAway()
    {
        
            StartCoroutine(destroyGlass(Glass));

            clientEntered = false;
            Glass = null;
            glassOrder1 = null;


        
    }

    public void checkOrder()
    {
        for (int i = 0; i < 3; i++)
        {
            if (glassOrder1[i] == clientOrder1[i])
            {
                points = points + 10;
                
            }
            
        }
        GameObject.FindObjectOfType<Points>().pointsTracker(points);
        orderFinished = true;

        if (isTutorial)
        {
            ActivateTip();
            isTutorial= false;

        }
        
    }
    public void ActivateTip()
    {
        actionActivate.Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("clients"))
        {
            clientEntered = true;
            Client = other.gameObject;
            clientOrder1 = Client.GetComponent<clientOrder>().glassOrder;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        clientEntered = false;
        
        clientOrder1 = null;
        orderFinished = false;
    }


    IEnumerator destroyGlass(GameObject object1)
    {
        yield return new WaitForSeconds(1f);
        
        Glass = null;
        Destroy(object1);
        glassIsOnTray = false;
        points = 0;
        Client.GetComponent<clientOrder>().orderFinished = true;
        yield return new WaitForSeconds(3f);
        Client.GetComponent<clientOrder>().orderFinished = false;





    }


}
