using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int scenetoLoad;
    public bool loadingScreen = false;
    public GameObject blueScreen;

    public void LoadScene()
    {
        
        Time.timeScale = 1;
        //blueScreen.SetActive(true);
        SceneManager.LoadScene(scenetoLoad);
    }

    private void Update()
    {
        
        if ( loadingScreen == true)
        {
            StartCoroutine(changetoMap());
        }
        
    }

    IEnumerator changetoMap()
    {
        Script_AudioManager.instance.PlaySFX("button");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scenetoLoad);
    }


    public void changeFromMainScene()
    {
        Script_AudioManager.instance.PlaySFX("button");
        StartCoroutine(mainScreenChange());
        
    }

    IEnumerator mainScreenChange()
    {
        blueScreen.SetActive(true);
        
        yield return new WaitForSecondsRealtime(1f);

        LoadScene();

    }
    



}
