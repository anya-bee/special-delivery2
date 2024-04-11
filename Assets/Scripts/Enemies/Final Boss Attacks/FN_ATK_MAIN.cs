using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_ATK_MAIN : MonoBehaviour
{
    
    public List<FN_PTH_MNG> attackManagers;
    public List<string> fruitAttackManagers;

    [Header("Dragon State")]
    public bool alreadyAttacked;
    public bool citricAttack;
    public Animator dragonAnimator;
    public int randomPitahayaStraw;

    [Header("Citric Spawn Attack")]
    public List<Transform> lemonSpawnPlaces;

    [Header("Dragon DMG")]
    public LayerMask dmgLayer;
    public Collider[] lemonColliders = new Collider[3];
    public float radius;

    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        for (int i =0; i< attackManagers.Count; i++)
        {
            fruitAttackManagers[i] = attackManagers[i].fruitType;
        }
    }

    // Update is called once per frame

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Update()
    {

        int insideLemons = Physics.OverlapSphereNonAlloc(this.transform.position, radius, lemonColliders, dmgLayer);
        if (insideLemons == 1)
        {

            
            if (lemonColliders[0].GetComponent<FN_Lemon_Bomb>().bossLemon == "bossLemon")
            {
                for (int i =0; i <3; i++)
                {
                    lemonColliders[i].GetComponent<FN_Lemon_Bomb>().destroySelf();
                }
            }
            
        }


        if (!alreadyAttacked)
        {
            randomPitahayaStraw = Random.Range(0, 1);
            spawnAttack(attackManagers[randomPitahayaStraw], fruitAttackManagers[randomPitahayaStraw]);
            alreadyAttacked = true;
            StartCoroutine(resetAttack());
        }

        if (!citricAttack)
        {
            StartCoroutine(limeAttack());
            citricAttack = true;
            StartCoroutine(resetLimes());
        }
            
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
