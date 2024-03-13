using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPushed : MonoBehaviour
{
    public float knockbackForce;
    public float knockBackTime;
    public float knockbackCounter;
    public bool damaged;
    
    


    public void pushEnemy()
    {
        knockbackCounter = knockBackTime;



        transform.position = transform.forward * knockbackForce;
    }
}
