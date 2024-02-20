using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class ActionTutorial_NextTutorialTip : Script_ActionsTutorial
{
    [SerializeField]
    ScriptableObject_TutorialTip nextTutorialTip;
    [SerializeField]
    float timeAfterPreviusTip;
    public override void Action()
    {
        
    }

    public override void Action(float time)
    {
        StartCoroutine(WaitToShow(time));
    }

    IEnumerator WaitToShow(float time)
    {

        yield return new WaitForSeconds(time);
        Tutorial.instance.ActivateTutorialBox(nextTutorialTip);
        foreach(Script_ActionsTutorial action in nextTutorialTip._actions)
        {
            action.Action();
        }
    }
}
