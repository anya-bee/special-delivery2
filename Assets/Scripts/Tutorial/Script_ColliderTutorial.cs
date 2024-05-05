using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ColliderTutorial : MonoBehaviour
{
    [SerializeField] ScriptableObject_TutorialTip tutorialTip;
    [SerializeField] string tagcollision = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != tagcollision) return;

        if(Tutorial.instance!= null) Tutorial.instance.ActivateTutorialBox(tutorialTip);
        
        foreach (Script_ActionsTutorial action in tutorialTip._actions)
        {
            action.Action();
            action.Action(tutorialTip._timeToShow);
        }
        
        this.gameObject.SetActive(false);
    }
}
