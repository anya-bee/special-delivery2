using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class boss_PulpiDash : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform tornadoPF;
    public float speed;
    public bool now = false;
    public bool deadStrawberry;


    void Start()
    {
        deadStrawberry = false;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(destroyAfteraWhile());
        if (GetComponent<EnemyHealth>().isDead == true)
        {
            Debug.Log("dead strawberry");
            FN_ATK_MAIN.deathStrawberry++;
            
            GetComponent<EnemyHealth>().dieAction();
        }

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
        Script_AudioManager.instance.PlayEnemySFX("pulpiFresa");
        var tornadoOne = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        tornadoOne.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        var tornadoTwo = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        tornadoTwo.GetComponent<Rigidbody>().velocity = spawnPoint.right * speed;
        var tornadoThree = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        tornadoThree.GetComponent<Rigidbody>().velocity = -spawnPoint.right * speed;
        var tornadoFour = Instantiate(tornadoPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        tornadoFour.GetComponent<Rigidbody>().velocity = -spawnPoint.forward * speed;



    }
    IEnumerator destroyAfteraWhile()
    {

        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }

}
