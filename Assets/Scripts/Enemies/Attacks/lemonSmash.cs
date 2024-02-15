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
        player.GetComponent<PlayerController>().stunnedState = true;
        if (player.GetComponent<PlayerController>().stunnedState == true)
        {
            
            if (first== false)
            {
                player.GetComponent<PlayerController>().speed = 0;
                player.GetComponent<Animator>().SetTrigger("isStunned");
                first = true;

                StartCoroutine(stunnedTime());
            }


        }
        
    }

    IEnumerator stunnedTime()
    {
        yield return new WaitForSeconds(stunnedVar);
        player.GetComponent<Animator>().SetTrigger("finishStun");
        stunnedState = false;
        first = true;
        player.GetComponent<PlayerController>().speed = orgSpeed;
    }
}
