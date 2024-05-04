using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class pulpifresa_Dash : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform tornadoPF;
    public float speed;
    public bool now = false;


    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {


       /*if (Input.GetKeyDown(KeyCode.Space))
        {
            var tornadoOne = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
            tornadoOne.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        }*/

    }


    public void shootTornado()
    {
        GetComponent<Animator>().SetTrigger("magicLeaf");
        StartCoroutine(fresaDash());
        
    }

    IEnumerator fresaDash()
    {
        yield return new WaitForSeconds(0.7f);
        Script_AudioManager.instance.PlaySFX("pulpiFresa");
        var tornadoOne = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        tornadoOne.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }


}
