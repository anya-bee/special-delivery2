using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
using UnityEditor.ShaderGraph;

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
    public float pushForce;

    [Header("VFX Reference")]
    public VisualEffect almaSlash;
    public VisualEffect strawberryVFX;
    public VisualEffect limeVFX;
    public VisualEffect lemonVFX;
    public Transform currentVfx;



    [Header("Emission")]
    public ComputeShader strawberry;

    private void Start()
    {
        
    }




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
        if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Strawberry_Enemy")
        {

            strawberryVFX.Play();
            c[0].gameObject.GetComponent<Animator>().SetTrigger("hitEnemy");
        }
        else if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Lime_Enemy")
        {
            limeVFX.Play();
        }
        else if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Lemon_Enemy") 
        {
            lemonVFX.Play();
            c[0].gameObject.GetComponentInChildren<Animator>().SetTrigger("hitEnemy");
        }
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
