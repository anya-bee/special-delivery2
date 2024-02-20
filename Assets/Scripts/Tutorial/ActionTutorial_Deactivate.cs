using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_Deactivate : Script_ActionsTutorial
{
    [SerializeField] GameObject objectToDeactivate;

    public override void Action()
    {
        objectToDeactivate.SetActive(false);
    }

    public override void Action(float time)
    {
        
    }
}
