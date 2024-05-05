using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitahaya_Explode : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform explosionObj;
    public Transform expLocation;
    public GameObject particlesPitahaya;
    public float explodeRadius;
    public int isInside;
    public bool dmgPlayer;
    public Collider[] playerCollider = new Collider[1];
    public LayerMask playerLayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, explodeRadius);
    }
    void Start()
    {
        expLocation = Instantiate(explosionObj, expLocation.position, Quaternion.identity);
        particlesPitahaya = expLocation.gameObject;
        expLocation.gameObject.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        expLocation.position = new Vector3(this.transform.position.x, this.transform.position.y +2, this.transform.position.z);
        isInside = Physics.OverlapSphereNonAlloc(transform.position, explodeRadius, playerCollider, playerLayer);
        if (isInside == 1)
        {
            dmgPlayer = true;
        }

    }


    public void explosion()
    {
        Script_AudioManager.instance.PlayEnemySFX("dragoncito");
        expLocation.gameObject.SetActive(true);
        if(dmgPlayer == true)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
        }
        
        Debug.Log("a pitahaya exploded!!!!!! BOOOOOOM");
        

    }

    IEnumerator waitToExplode()
    {

        yield return new WaitForSeconds(1.1f);

    }



}
