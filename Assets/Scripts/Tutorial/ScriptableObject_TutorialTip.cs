using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class ScriptableObject_TutorialTip : MonoBehaviour
{

    [SerializeField] LocalizedString textToDisplay;
    public LocalizedString _textToDisplay
    {
        get
        {
            return this.textToDisplay;
        }
        set
        {
            this.textToDisplay = value;
        }
    }
    [SerializeField] float timeToShow;
    public float _timeToShow
    {
        get
        {
            return this.timeToShow;
        }
        set
        {
            this.timeToShow = value;
        }
    }
    [SerializeField] Script_ActionsTutorial[] actions;
    public Script_ActionsTutorial[] _actions
    {
        get
        {
            return this.actions;
        }
        set
        {
            this._actions = value;
        }
    }



}
