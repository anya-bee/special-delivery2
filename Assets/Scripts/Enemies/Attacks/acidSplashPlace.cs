using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class acidSplashPlace : MonoBehaviour
{
    public VisualEffect acidVFX;
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
        playerinSight = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        if (playerinSight)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed = 2;
            

        }
        else
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed = 6;
        }


    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(10f);

        Destroy(this.gameObject);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
