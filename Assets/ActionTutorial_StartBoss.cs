using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_StartBoss : Script_ActionsTutorial
{
    [SerializeField] FN_ATK_MAIN DragonAttack;
    public override void Action()
    {
        DragonAttack.BossStart = true;
    }

    public override void Action(float time)
    {

    }
}
