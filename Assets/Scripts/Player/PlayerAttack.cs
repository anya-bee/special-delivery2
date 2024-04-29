using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
using UnityEngine.Events;
using UnityEditor.ShaderGraph;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerSword;
    public bool bossBattle;
    public Transform attackRange;
    public float radius;
    public LayerMask enemiesLayer;
    public LayerMask bossLayer;
    public Collider[] enemyCollider = new Collider[1];
    public float damagePlayer;
    public bool attackMode = false;

    [Header("Enemy")]
    public bool enemyInrange;
    public float pushForce;
    public UnityEvent dragonHit;

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
        StartCoroutine(playVFX());
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, enemyCollider, enemiesLayer);
        int numColliders5 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, enemyCollider, bossLayer);

        if(numColliders5 == 1)
        {
            dragonHit.Invoke();
        }

        if (numColliders2 == 1)
        {

            if (bossBattle)
            {
                StartCoroutine(attackInterval(enemyCollider));

                transform.LookAt(enemyCollider[0].gameObject.transform);

                if (enemyCollider[0].GetComponent<FN_Lemon_Bomb>().bossLemon == "bossLemon")
                {
                    enemyCollider[0].GetComponent<FN_Lemon_Bomb>().checkSword = true;
                    enemyCollider[0] = null;
                }
                
                
                
                    
                
            }
            else
            {
                StartCoroutine(attackInterval(enemyCollider));

                transform.LookAt(enemyCollider[0].gameObject.transform);
            }
            


        }

        
    }
    IEnumerator playVFX()
    {
        yield return new WaitForSeconds(0.5f);
        almaSlash.Play();
    }

    IEnumerator attackInterval(Collider[] c)
    {
        yield return new WaitForSeconds(0.2f);
        
        Script_AudioManager.instance.PlaySFX("stab");
        if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Strawberry_Enemy")
        {

            strawberryVFX.Play();
            c[0].gameObject.GetComponent<Animator>().SetTrigger("hitEnemy");
        }
        else if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Lime_Enemy")
        {
            limeVFX.Play();
            c[0].gameObject.GetComponent<Animator>().SetTrigger("hitEnemy");
        }
        else if (c[0].gameObject.GetComponent<EnemyHealth>().enemyString == "Lemon_Enemy") 
        {
            lemonVFX.Play();
            c[0].gameObject.GetComponentInChildren<Animator>().SetTrigger("hitEnemy");
        }
        else
        {
            Debug.Log("boss Lemon");
        }
        yield return new WaitForSeconds(0.5f);
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
