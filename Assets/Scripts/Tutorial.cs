using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Components;

public class Tutorial : MonoBehaviour
{

    [SerializeField] GameObject uiBox;
    [SerializeField] LocalizeStringEvent dialogue;
    Coroutine deactivateBox;
    //Singleton Structure
    private static Tutorial _instance;
    public static Tutorial instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Tutorial>();
            }
            return _instance;
        }
    }

    public void ActivateTutorialBox(ScriptableObject_TutorialTip tutorialTip)
    {
        Debug.Log("activatecall");
        if (uiBox.gameObject.activeSelf)
        {
            Debug.Log("emtrp");
            StopCoroutine(deactivateBox);
        }

        uiBox.SetActive(true);
        dialogue.StringReference = tutorialTip._textToDisplay;
        deactivateBox = StartCoroutine(DeactivateTutorialBox(tutorialTip._timeToShow));
    }

    IEnumerator DeactivateTutorialBox(float time)
    {
        yield return new WaitForSeconds(time);
        uiBox.SetActive(false);
    }


}
