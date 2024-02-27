using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidSplashPlace : MonoBehaviour
{

    public bool playerinSight;
    public float sightRange;
    public LayerMask whatisPlayer;
    public float originalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroySelf());
        

    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed = 2;
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed = 6;
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(8);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed = 6;
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
