using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBullet : MonoBehaviour
{
    public string orbType;
    public GameObject player;
    public powerUps playerPU;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        playerPU = player.GetComponent<powerUps>();
        playerPU.currentPowerUp = orbType;
        Destroy(this.gameObject);

    }


    
}
