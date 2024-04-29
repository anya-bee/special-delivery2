using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadoBullet : MonoBehaviour


{
    public bool playerinSight;
    public float sightRange;
    public LayerMask whatisPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroySelf());
        playerinSight = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        if (playerinSight)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetLayerWeight(1, 1f);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().startCoroutineForHits();


            Destroy(this.gameObject);

        }
        
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(4);
        
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    
}
