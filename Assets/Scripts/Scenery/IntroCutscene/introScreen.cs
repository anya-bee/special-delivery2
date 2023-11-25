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
    public Color transparent;
    public Color fullcolor;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        
    }


    IEnumerator appearLogo()
    {
        yield return new WaitForSeconds(3f);
        
    }

}
