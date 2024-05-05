using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_ActivateMusic : Script_ActionsTutorial
{
    [SerializeField] Script_Music Musica;
    public override void Action()
    {
        Script_AudioManager.instance.PlayBGM("bossBattle");
    }

    public override void Action(float time)
    {
       
    }

}
