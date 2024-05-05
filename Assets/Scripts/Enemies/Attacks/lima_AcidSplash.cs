using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class lima_AcidSplash : MonoBehaviour
{

    public Transform spawnPoint;
    public Transform acidPF;
    public VisualEffect originalSplash;
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


    public void shootAcid()
    {
        GetComponent<Animator>().SetTrigger("magicLeaf");
        StartCoroutine(fresaDash());

    }

    IEnumerator fresaDash()
    {
        originalSplash.Play();
        Script_AudioManager.instance.PlayEnemySFX("limeAcid");
        yield return new WaitForSeconds(0.3f);
        
        var tornadoOne = Instantiate(acidPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //tornadoOne.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }

}
