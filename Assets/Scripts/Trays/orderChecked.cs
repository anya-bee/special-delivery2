using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderChecked : MonoBehaviour
{
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
            checkOrder();
        }
        
        if(orderFinished == true)
        {
            clientEntered = false;
            Glass = null;
            glassOrder1 = null;
            Client = null;
            clientOrder1 = null;
            Destroy(Glass);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public void checkOrder()
    {
        for (int i = 0; i < 3; i++)
        {
            if (glassOrder1[i] == clientOrder1[i])
            {
                points = points + 10;
                break;
            }
            
        }
        orderFinished = true;
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
        Client = null;
        clientOrder1 = null;
    }


}
