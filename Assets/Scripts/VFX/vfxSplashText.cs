using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class vfxSplashText : MonoBehaviour
{

    public GameObject vfxtest;
    public VisualEffect v1;
    [ColorUsage(true, true)]
    public Color color1;
    // Start is called before the first frame update
    void Start()
    {
        v1 = vfxtest.GetComponent<VisualEffect>();
        //v1.gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)){
            v1.Play();
        }

        v1.SetVector4("Color01", color1);
    }
}
