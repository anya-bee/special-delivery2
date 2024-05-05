using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_StartBoss : Script_ActionsTutorial
{
    [SerializeField] FN_ATK_MAIN DragonAttack;
    public override void Action()
    {
        StartCoroutine(Animationtransform(5f));
    }

    public override void Action(float time)
    {

    }

    IEnumerator Animationtransform(float duration)
    {


        yield return new WaitForSeconds(duration);
        DragonAttack.BossStart = true;
        DragonAttack.healthBar.gameObject.SetActive(true);


    }
}
