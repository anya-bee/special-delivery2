using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lima_AcidSplash : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform splashPF;
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
        var tornadoOne = Instantiate(splashPF, spawnPoint.transform.position, spawnPoint.transform.rotation);
        
    }
}
