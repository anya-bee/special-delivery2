using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_ATK_MAIN : MonoBehaviour
{
    
    public List<FN_PTH_MNG> attackManagers;
    public List<string> fruitAttackManagers;

    [Header("Dragon State")]
    public string dragonState;
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

    IEnumerator startAttack()
    {
        
        yield return new WaitForSeconds(6);

        //spawnAttack(attackManagers[randomPitahayaStraw], dragonState);
        
    }
}
