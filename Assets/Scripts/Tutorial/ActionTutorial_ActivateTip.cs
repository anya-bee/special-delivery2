using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_ActivateTip : Script_ActionsTutorial
{
    [SerializeField] private GameObject tutorialToActivate;
    public override void Action()
    {
        tutorialToActivate.SetActive(true);
    }

    public override void Action(float time)
    {
        
    }
}
