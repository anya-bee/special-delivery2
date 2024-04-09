using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_ATK_MAIN : MonoBehaviour
{
    
    public List<FN_PTH_MNG> attackManagers;
    public List<string> fruitAttackManagers;

    [Header("Dragon State")]
    public bool alreadyAttacked;
    public Animator dragonAnimator;
    public int randomPitahayaStraw;

    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        for (int i =0; i< attackManagers.Count; i++)
        {
            fruitAttackManagers[i] = attackManagers[i].fruitType;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyAttacked)
        {
            randomPitahayaStraw = Random.Range(0, 2);
            spawnAttack(attackManagers[randomPitahayaStraw], fruitAttackManagers[randomPitahayaStraw]);
            alreadyAttacked = true;
            StartCoroutine(resetAttack());
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
}
