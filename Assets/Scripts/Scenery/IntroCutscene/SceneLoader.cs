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
        blueScreen.SetActive(true);
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
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scenetoLoad);
    }


    public void changeFromMainScene()
    {
        StartCoroutine(mainScreenChange());
        
    }

    IEnumerator mainScreenChange()
    {
        blueScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        LoadScene();

    }
    



}
