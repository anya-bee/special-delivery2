using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBullet : MonoBehaviour
{
    public string orbType;
    public Transform player;
    public powerUps playerPU;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player.GetComponent<powerUps>().currentPowerUp = orbType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        
        
        

    }




    
}
