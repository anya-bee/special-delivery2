using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FruitsTutorial : MonoBehaviour
{
    [SerializeField] clientOrder tutorialOrder;
    [SerializeField] PlayerInventory2 playerInventory;
    [SerializeField] ScriptableObject_TutorialTip tutorialTip;
    bool firstFruit=false;
    bool secondFruit=false;
    bool thirdFruit = false;
    public void Update()
    {
        Check();

        if(firstFruit&&secondFruit&&thirdFruit)
        {
            tutorialtip();
        }


    }
    public void Check()
    {
        foreach(Fruits fruit in playerInventory._inventory.getFruitsList())
        {
            if (tutorialOrder.glassOrder[0] == fruit.GetString())
            {
                firstFruit= true;
            }
            if (tutorialOrder.glassOrder[1] == fruit.GetString())
            {
                if(tutorialOrder.glassOrder[0] == tutorialOrder.glassOrder[1] && fruit.amount == 2)
                {
                    secondFruit = true;
                }

                
            }
            if (tutorialOrder.glassOrder[2] == fruit.GetString())
            {
                thirdFruit = true;
            }
        }
        
    }


    private void tutorialtip()
    {
        Tutorial.instance.ActivateTutorialBox(tutorialTip);

        foreach (Script_ActionsTutorial action in tutorialTip._actions)
        {
            action.Action();
            action.Action(tutorialTip._timeToShow);
        }

        this.gameObject.SetActive(false);
    }
}
