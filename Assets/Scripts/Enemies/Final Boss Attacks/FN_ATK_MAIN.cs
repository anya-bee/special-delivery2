using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FN_ATK_MAIN : MonoBehaviour
{
    
    public List<FN_PTH_MNG> attackManagers;
    public List<string> fruitAttackManagers;
    

    [Header("Health")]
    public EnemyHealth bossHealth;
    public Image healthBar;
    public float health;
    public int lemons;

    [Header("Dragon State")]
    public bool alreadyAttacked;
    public bool citricAttack;
    public Animator dragonAnimator;
    public int randomPitahayaStraw;

    [Header("Citric Spawn Attack")]
    public List<Transform> lemonSpawnPlaces;

    [Header("Pulpidash")]
    List<GameObject> pulpifresas;

    [Header("Dragon DMG")]
    public LayerMask dmgLayer;
    public Collider[] lemonColliders = new Collider[3];
    public float radius;
    public bool strawberriesField = false;

    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        for (int i =0; i< attackManagers.Count; i++)
        {
            fruitAttackManagers[i] = attackManagers[i].fruitType;
        }
        health = 100;
    }

    // Update is called once per frame

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Update()
    {
        healthBar.fillAmount = health / 100;
        int insideLemons = Physics.OverlapSphereNonAlloc(this.transform.position, radius, lemonColliders, dmgLayer);


        if ( fruitAttackManagers[2].)

        if ( insideLemons >0)
        {
            for ( int i = 0; i<3; i++)
            {
                if (lemonColliders[i] != null)
                {
                    lemonColliders[i].gameObject.GetComponent<FN_Lemon_Bomb>().destroySelf();
                    health -= 5;
                    CameraShake.Invoke();
                    lemonColliders[0] = null;
                    StartCoroutine(dragonHit());

                }
            }

            
        }


        if (!alreadyAttacked)
        {
            randomPitahayaStraw = Random.Range(1, 2);
            spawnAttack(attackManagers[randomPitahayaStraw], fruitAttackManagers[randomPitahayaStraw]);
            alreadyAttacked = true;
            strawberriesField = true;
            StartCoroutine(resetAttack());
        }

        if (!citricAttack)
        {
            StartCoroutine(limeAttack());
            citricAttack = true;
            StartCoroutine(resetLimes());
        }


            
    }


    IEnumerator dragonHit()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1f);
        yield return new WaitForSeconds(0.8f);
        GetComponent<Animator>().SetLayerWeight(1, 0f);
    }

    public void spawnAttack(FN_PTH_MNG attack,string fruitType)
    {
        
            dragonAnimator.SetTrigger(fruitType);
            attack.invokeFruitBombs();
            alreadyAttacked = true;


    }
    private void resetAction()
    {
        alreadyAttacked = false;

    }

    public void spawnDragonBombs()
    {
        
    }

    IEnumerator resetAttack()
    {
        
        yield return new WaitForSeconds(15);
        alreadyAttacked = false;
        strawberriesField = false;
        //spawnAttack(attackManagers[randomPitahayaStraw], dragonState);
        
    }
    IEnumerator resetLimes()
    {

        yield return new WaitForSeconds(15);
        citricAttack = false;
        //spawnAttack(attackManagers[randomPitahayaStraw], dragonState);

    }

    IEnumerator limeAttack()
    {
        dragonAnimator.SetTrigger("limes_ATK");
        yield return new WaitForSeconds(1.1f);
        attackManagers[2].invokeCitrics(lemonSpawnPlaces[0]);
        yield return new WaitForSeconds(1f);
        attackManagers[2].invokeCitrics(lemonSpawnPlaces[1]);
        yield return new WaitForSeconds(0.5f);
        attackManagers[2].invokeCitrics(lemonSpawnPlaces[2]);



    }
}
