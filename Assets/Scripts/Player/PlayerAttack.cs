using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerSword;
    public Transform attackRange;
    public float radius;
    public LayerMask enemiesLayer;
    public Collider[] enemyCollider = new Collider[1];
    public float damagePlayer;
    public bool attackMode = false; 


    void Start()
    {
        
    }

    // Update is called once per frame

 

    public void attackState()
    {
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, enemyCollider, enemiesLayer);

        if (numColliders2 == 1)
        {
            playerSword.SetActive(true);
            StartCoroutine(attackInterval(enemyCollider));


        }

        
    }


    IEnumerator attackInterval(Collider[] c)
    {

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < c.Length; i++)
        {
            c[i].gameObject.GetComponent<EnemyHealth>().Damage(damagePlayer);
        }
        if(c[0].gameObject.GetComponent<EnemyHealth>().currentLifeAmount <= 0)
        {
            c[0] = null;
        }
        Debug.Log("+1");
        playerSword.SetActive(false);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRange.position, radius);
    }
}
