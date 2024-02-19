using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerSword;
    public Transform attackRange;
    public float radius;
    public LayerMask enemiesLayer;
    public Collider[] enemyCollider = new Collider[1];
    public float damagePlayer;
    public bool attackMode = false;

    [Header("Enemy")]
    public bool enemyInrange;

    [Header("VFX")]
    public VisualEffect almaSlash;



    void Start()
    {
        
    }

    // Update is called once per frame

 

    public void attackState()
    {
        playerSword.SetActive(true);
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, enemyCollider, enemiesLayer);

        if (numColliders2 == 1)
        {
            
            StartCoroutine(attackInterval(enemyCollider));
            transform.LookAt(enemyCollider[0].gameObject.transform);


        }

        
    }


    IEnumerator attackInterval(Collider[] c)
    {
        yield return new WaitForSeconds(0.4f);
        almaSlash.Play();
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
        
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRange.position, radius);
    }
}
