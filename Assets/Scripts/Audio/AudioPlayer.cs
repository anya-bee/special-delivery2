using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioReference
{
    public string audioName;
    public AudioClip audioClip;
}

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public List<AudioReference> audioReferences = new List<AudioReference>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFXAudio(string _audioName)
    {
        AudioReference audioReference = null;
        audioReference = audioReferences.Find((audioReference) => audioReference.audioName == _audioName);

        if (audioReference != null)
        {
            audioSource.Stop();
            if(audioReference.audioClip != null)
            {
                audioSource.clip = audioReference.audioClip;
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("No se encontro Audio Reference con nombre de: " + _audioName + ", en el objeto " + this.gameObject.name);
        }
    }
}
