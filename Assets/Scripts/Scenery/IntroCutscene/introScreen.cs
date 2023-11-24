using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class introScreen : MonoBehaviour
{
    public Image logo;
    public float logoappear;
    public float alphadur;


    // Start is called before the first frame update
    void Start()
    {
        logo.CrossFadeAlpha(1, alphadur, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator appearLogo()
    {
        yield return new WaitForSeconds(logoappear);
        logo.CrossFadeAlpha(1, alphadur, false);
    }

}
