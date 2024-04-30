using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class FN_ATK_MAIN : MonoBehaviour
{
    
    public List<FN_PTH_MNG> attackManagers;
    public List<string> fruitAttackManagers;
    public static int deathStrawberry = 0;


    [Header("Health")]
    public EnemyHealth bossHealth;
    public Image healthBar;
    public float health;
    public int lemons;

    [Header("Dragon State")]
    public bool alreadyAttacked;
    public float pitahayaCounter = 0;
    public bool citricAttack;
    public Animator dragonAnimator;
    public int randomPitahayaStraw;
    public VisualEffect dizzyDragon;

    [Header("Citric Spawn Attack")]
    public List<Transform> lemonSpawnPlaces;




    [Header("Dragon DMG")]
    public LayerMask dmgLayer;
    public Collider[] lemonColliders = new Collider[3];
    public float radius;
    public bool strawberriesField = false;

    [Header("Ending Screen")]
    public GameObject endingScreen;

    void Start()
    {
        endingScreen.SetActive(false);
        dizzyDragon.gameObject.SetActive(false);
        dragonAnimator = GetComponent<Animator>();
        for (int i =0; i< attackManagers.Count; i++)
        {
            fruitAttackManagers[i] = attackManagers[i].fruitType;
        }
        health = 100;
        alreadyAttacked = false;
        
    }

    // Update is called once per frame

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void hitDragon()
    {
        Script_AudioManager.instance.PlaySFX("stab");
        health -= 5;
        CameraShake.Invoke();
        StartCoroutine(dragonHit());
    }
    void Update()
    {
        healthBar.fillAmount = health / 100;
        int insideLemons = Physics.OverlapSphereNonAlloc(this.transform.position, radius, lemonColliders, dmgLayer);

        /*for ( int i = 0; i < 3; i++)
        {
            pulpifresas[i] = attackManagers[1].spawnLocations[i].currentBomb;
            if (pulpifresas[i].GetComponent<boss_PulpiDash>().deadStrawberry == true) { 
            }
        }*/

        if( health < 0)
        {
            endingScreen.SetActive(true);
            Script_AudioManager.instance.PauseBGM(true);
            Script_AudioManager.instance.PlaySFX("enterLevelSound");

        }
        
        

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

        if( deathStrawberry == 3)
        {
            GetComponent<Animator>().SetTrigger("dizzy");
            StartCoroutine(longDragonHit());
            deathStrawberry = 0;
        }


        if (alreadyAttacked == false)
        {
            randomPitahayaStraw = Random.Range(0, 2);
            spawnAttack(attackManagers[randomPitahayaStraw], fruitAttackManagers[randomPitahayaStraw]);
            

            alreadyAttacked = true;

            strawberriesField = true;
            StartCoroutine(resetAttack(randomPitahayaStraw));
        }

        if (citricAttack == false)
        {
            StartCoroutine(limeAttack());
            citricAttack = true;
            StartCoroutine(resetLimes());
        }


           
    }
    IEnumerator dragonAttackPattern()
    {
        alreadyAttacked = false;
        yield return new WaitForSeconds(40f);
        citricAttack = false;
        yield return new WaitForSeconds(40f);

    }


    IEnumerator dragonHit()
    {

        GetComponent<Animator>().SetLayerWeight(1, 1f);
        yield return new WaitForSeconds(0.8f);
        GetComponent<Animator>().SetLayerWeight(1, 0f);
    }

    IEnumerator longDragonHit()
    {
        Script_AudioManager.instance.PlaySFX("rest");
        dizzyDragon.Play();
        dizzyDragon.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        dizzyDragon.gameObject.SetActive(false);
        deathStrawberry = 0;
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

    IEnumerator resetAttack(int n)
    {
        if (n == 0 && pitahayaCounter < 2)
        {
            pitahayaCounter++;
            yield return new WaitForSeconds(6f);
            alreadyAttacked = false;
        }
        else
        {
            pitahayaCounter = 0;
            yield return new WaitForSeconds(15f);
            citricAttack = false;
            deathStrawberry = 0;
            strawberriesField = false;
        }
        
        //spawnAttack(attackManagers[randomPitahayaStraw], dragonState);
        
    }
    IEnumerator resetLimes()
    {

        yield return new WaitForSeconds(10f);
        alreadyAttacked = false;
        citricAttack = true;
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
