using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class pulpifresa_Dash : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform tornadoPF;
    public Transform dashDirection;
    public float speed;
    public bool now = false;


    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {


       if (Input.GetKeyDown(KeyCode.Space))
        {
            var tornadoOne = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
            tornadoOne.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        }

    }


    /*public void shootTornado()
    {
        tornadoStart = Instantiate(tornadoPF, transform.position, transform.rotation);
        tornadoGameobject = tornadoStart.gameObject;

        tornadoGameobject.SetActive(true);

        Rigidbody tornadoRB = tornadoGameobject.GetComponent<Rigidbody>();
        tornadoRB.AddForce(tornadoRB.transform.forward * speed);
    }*/




}
