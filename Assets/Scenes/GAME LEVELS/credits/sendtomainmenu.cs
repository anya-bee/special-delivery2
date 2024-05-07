using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendtomainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gotoMainScene());
    }

    IEnumerator gotoMainScene()
    {
        yield return new WaitForSeconds(13f);
        GetComponent<SceneLoader>().LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
