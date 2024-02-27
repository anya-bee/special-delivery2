using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemonSmash : MonoBehaviour
{
    [Header("Status Ailments")]
    public float stunnedTimeRecover;
    private bool first = false;
    public GameObject player;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stunPlayer()
    {
        if (first == false)
        {
            player.GetComponent<PlayerController>().stunnedState = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
            player.GetComponent<PlayerController>().StunnedEffect();
            first = true;

        }
        
    }

    IEnumerator stunnedTime()
    {

        yield return new WaitForSeconds(stunnedTimeRecover);
        first= false;
    }
}
