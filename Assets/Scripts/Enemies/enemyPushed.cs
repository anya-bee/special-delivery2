using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPushed : MonoBehaviour
{
    public float knockbackForce;
    public float knockBackTime;
    public float knockbackCounter;
    public bool damaged;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (knockbackCounter <= 0)
        {
            Debug.Log("nothinghappened");
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
    }



    public void pushEnemy()
    {
        knockbackCounter = knockBackTime;



        transform.position = transform.forward * knockbackForce;
    }
}
