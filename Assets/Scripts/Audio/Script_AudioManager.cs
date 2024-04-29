using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioRef
{
    public string name;
    public AudioClip audioClip;
}

public class Script_AudioManager : MonoBehaviour
{
    private static Script_AudioManager _instance;

    public static Script_AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Script_AudioManager>();
            }

            return _instance;
        }
    }

    private static Script_AudioManager dontDestroyOnLoadScript_AudioManager;

    private void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    [Header("Audio Controls")]
    public AudioMixer mixer;
    public AudioSource bgSource;
    public AudioSource sfxSource;
    public AudioSource playerSource;
    public AudioSource enemySource;

    [Header("Pitch")]
    public float minPitch;
    public float maxPitch;

    [Header("Volume")]
    public float minVol;
    public float maxVol;

    [Header("Audio Clips")]
    public List<AudioRef> bgAudio = new List<AudioRef>();
    public List<AudioRef> sfxAudio = new List<AudioRef>();
    public List<AudioRef> playerAudio = new List<AudioRef>();
    public List<AudioRef> enemyAudio = new List<AudioRef>();

    public bool dungeonStarted {get; private set;}
    public string currentBGM {get; private set;}

    private float safeVolume;

    private void Start()
    {
        
    }

    public void PlayBGM(string name)
    {
        foreach (AudioRef reference in bgAudio){

            if(reference.name == name)
            {
                currentBGM = name;
                bgSource.clip = reference.audioClip;
                bgSource.Play();
                break;
            }
            
        }
    }

    public void PauseBGM(bool toggle){

        if(toggle){
            bgSource.Pause();
        }
        else{
            bgSource.UnPause();
        }
        
    }

    public string CurrentBGM(){

        if(bgSource.clip != null){
            return bgSource.clip.name;
        }
        else{
            return null;
        }   
    }

    public void StartDungeon(){
        dungeonStarted = true;
    }

    public void PlayPlayerSFX(string name)
    {
        foreach (AudioRef reference in playerAudio){

            if (reference.name == name)
            {
                playerSource.clip = reference.audioClip;
                playerSource.Play();
                break;
            }

        }
    }

    public void PlayEnemySFX(string name)
    {
        foreach (AudioRef reference in enemyAudio){

            if (reference.name == name)
            {
                enemySource.clip = reference.audioClip;
                enemySource.Play();
                break;
            }

        }
    }

    private void randomSound()
    {
        

        sfxSource.pitch = Random.Range(minPitch, maxPitch);

        sfxSource.volume = Random.Range(minVol, maxVol);

    }

    public void PlaySFX(string name)
    {
        foreach (AudioRef reference in sfxAudio){

            if (reference.name == name)
            {
                sfxSource.clip = reference.audioClip;
                randomSound();
                sfxSource.Play();
                break;
            }

        }
    }
    public void ChangeVolume(int i, float volume)
    {
        if(i == 0){
            bgSource.volume = volume;
        }
        if (i == 1)
        {
            sfxSource.volume = volume;
        }
        if (i == 2)
        {
            playerSource.volume = volume;
        }
        if (i == 3)
        {
            enemySource.volume = volume;
        }
    }

    public void PauseToggle(bool toggle){
        if(toggle){
            //paused
            
            bgSource.volume = bgSource.volume/5f;
        }
        if(!toggle){
            //resume
            safeVolume = bgSource.volume;
            bgSource.volume = safeVolume;
        }
    }
}
