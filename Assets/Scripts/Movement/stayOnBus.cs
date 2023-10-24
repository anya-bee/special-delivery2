using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOnBus : MonoBehaviour
{
    // this code detects if the player is inside or outside the bus 
    public Transform target;
    public bool isInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = null;
            isInside = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().isOnBus = true;
        }


        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = GameObject.FindWithTag("Player").transform;
            isInside = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().isOnBus = false;
        }

        
    }


}
