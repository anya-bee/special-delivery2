using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class lima_AcidSplash : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform splashPF;
    public VisualEffect splashVFX;
    public float speed;
    public bool now = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void acidSplash()
    {
        GetComponent<Animator>().SetTrigger("acidS");
        StartCoroutine(fresaDash());

    }

    IEnumerator fresaDash()
    {
        yield return new WaitForSeconds(0.7f);
        splashVFX.Play();
        //var tornadoOne = Instantiate(splashPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        
    }
}
