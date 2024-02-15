using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemonSmash : MonoBehaviour
{
    [Header("Status Ailments")]
    public bool dizzyState = false;
    public bool stunnedState = false;
    public float stunnedVar;
    private bool first = false;
    public GameObject player;
    public float orgSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        orgSpeed = player.GetComponent<PlayerController>().speed;
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
            if (player.GetComponent<PlayerController>().stunnedState == true)
            {


                player.GetComponent<PlayerController>().speed = 0;
                player.GetComponent<Animator>().SetTrigger("isStunned");
                first = true;
                player.gameObject.GetComponent<PlayerHealth>().Damage(1);

                StartCoroutine(stunnedTime());



            }
        }
        
    }

    IEnumerator stunnedTime()
    {
        first = true;
        yield return new WaitForSeconds(stunnedVar);
        player.GetComponent<Animator>().SetTrigger("finishStun");
        player.GetComponent<PlayerController>().stunnedState = false;
        
        player.GetComponent<PlayerController>().speed = orgSpeed;
    }
}
