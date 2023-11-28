using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Music : MonoBehaviour
{
    [SerializeField] private string bgmName;
    [SerializeField] private bool manualStart = false;

    private void Start(){
        if(!manualStart){
            if(Script_AudioManager.instance.currentBGM != bgmName){
                Script_AudioManager.instance.PlayBGM(bgmName);
            }
        }
    }

    public void StartDungeon(){
        if(!Script_AudioManager.instance.dungeonStarted){
            Script_AudioManager.instance.PlayBGM(bgmName);
            Script_AudioManager.instance.StartDungeon();
        }
    }

    public void ManualPlay(){
        Script_AudioManager.instance.PlayBGM(bgmName);
    }

    public string StageMusic(){
        return bgmName;
    }
}
