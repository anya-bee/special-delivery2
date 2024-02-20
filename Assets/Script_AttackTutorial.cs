using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AttackTutorial : MonoBehaviour
{
    [SerializeField] ScriptableObject_TutorialTip tutorialTip;
    //[SerializeField] PlayerAttack playerAttack;
    [SerializeField] SphereCollider colTrigger;
    //LayerMask enemieLayer;
    public void Start()
    {
        //colTrigger.radius = playerAttack.radius;
        //colTrigger.center = playerAttack.attackRange.position;
        //enemieLayer = playerAttack.enemiesLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemies") return;

        Tutorial.instance.ActivateTutorialBox(tutorialTip);

        foreach (Script_ActionsTutorial action in tutorialTip._actions)
        {
            action.Action();
            action.Action(tutorialTip._timeToShow);
        }

        this.gameObject.SetActive(false);
    }
}
