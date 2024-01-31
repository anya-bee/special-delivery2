using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_ATK_Explode : MonoBehaviour
{
    public bool playerHasEntered = false;
    public bool groundInSight;
    public bool groundAndPlayer;
    public float sightRange;
    public int dmg;
    public LayerMask whatisGround;
    public LayerMask groundAndPlayerLayer;
    public Rigidbody pitahayaRG;

    private void Start()
    {
        pitahayaRG.AddForce(transform.up * 10f);
    }

    private void Update()
        
    {
        groundInSight = Physics.CheckSphere(transform.position, sightRange, whatisGround);
        groundAndPlayer = Physics.CheckSphere(transform.position, sightRange, groundAndPlayerLayer);

        if (GetComponent<EnemyHealth>().isDead == true)
        {
          GetComponent<EnemyHealth>().dieAction();
        }
        if (groundAndPlayer)
        {
            gameObject.GetComponent<EnemyHealth>().currentLifeAmount = 0;
            playerHasEntered = true;

            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
        }

        else if (groundInSight)
        {
            gameObject.GetComponent<EnemyHealth>().currentLifeAmount = 0;
            playerHasEntered = true;
            
            //GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(2);
        }

        

        if (!groundInSight)
        {
            playerHasEntered = false;
        }

    }
}
