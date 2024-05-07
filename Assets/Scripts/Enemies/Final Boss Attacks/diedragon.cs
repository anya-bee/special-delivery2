using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diedragon : MonoBehaviour

{

    public GameObject dieScreen;
    // Start is called before the first frame update
    void Start()
    {
        dieScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cameraShakeEnding());
    }


    IEnumerator cameraShakeEnding()
    {
        CameraShake.Invoke();
        yield return new WaitForSeconds(2f);
        CameraShake.Invoke();
        yield return new WaitForSeconds(2f);
        CameraShake.Invoke();
        yield return new WaitForSeconds(5f);
        dieScreen.SetActive(true);

    }
}
