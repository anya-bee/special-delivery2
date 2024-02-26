using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

[Serializable]
public class Escene
{
    [SerializeField] String Name;
    [SerializeField] LocalizedString key;
    [SerializeField] Sprite image;
    

    public LocalizedString getdialogue()
    {
        return key;
    }

    public Sprite getimage()
    {
        return image;
    }
}

public class script_ChangeTextAction : MonoBehaviour
{
    [SerializeField] Escene[] Escenes;
    [SerializeField] private LocalizeStringEvent localizedStringEvent;
    [SerializeField] private Image imageComponent;
    [SerializeField] private Color newColor;
    [SerializeField] private float AnimationTime = .8f;
    [SerializeField] private float textDelay = .8f;
     public Animator magicAnimator;
    int i = 0;

    private void Start()
    {
        changetext();
        Destroy(magicAnimator, 6);

    }

    public void colorWhite()
    {
        imageComponent.color = newColor;
    }

    public void changetext()
    {
        if (i >= Escenes.Length - 1)
        {
            //scene.ChangeRoom();
            return;
        }
        

        i++;
        
        localizedStringEvent.StringReference = Escenes[i].getdialogue();
        
        imageComponent.sprite = Escenes[i].getimage();

        if (Escenes[i].getimage() != Escenes[i-1].getimage())
        {
            //imageComponent.gameObject.GetComponent<Animation_Shake>().Animation(AnimationTime);
        }

        
        
    }


}


