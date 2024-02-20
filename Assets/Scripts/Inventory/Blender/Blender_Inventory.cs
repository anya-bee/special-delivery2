using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blender_Inventory : MonoBehaviour
{

    //this is the main blender code, which makes smoothies 

    public bool isOnBlender = false;
    public List<string> fruitList;
    public int fruitsOnBlender;
    public Animator blenderAnimator;


    [Header("juiceGenerator")]
    public Transform prefabJuice;
    public string juiceType;
    private Renderer fruitrender1;
    public GameObject blender;
    public Transform newLocation;

    [Header("Tutorial")]
    [SerializeField] bool isTutorial=false;
    [SerializeField] Script_ActionsTutorial actionActivate;

    private void Start()
    {
        isOnBlender = false;
        blender = this.gameObject;
        fruitList.Add("");
        fruitList.Add("");
        fruitList.Add("");
    }

    private void refreshSmoothie()
    {
        fruitList.Clear();
    }

    private void Update()
    {
        if (isOnBlender && fruitsOnBlender == 0)
        {
            blenderAnimator.SetBool("openBlender", true);
            
        }
        
    }

    public void SetJuice(List<string> juiceOrder)
    {

        Transform transform = Instantiate(prefabJuice, newLocation.position, Quaternion.identity);
        juiceGlass juiceGlass1 = transform.GetComponent<juiceGlass>();
        foreach(string fruitItem in juiceOrder)
        {
            juiceGlass1.glassOrder.Add(fruitItem);
        }
        juiceGlass1.juiceType = juiceGlass1.glassOrder[0]; 
        juiceGlass1.juiceColor = juiceGlass1.GetColor();

        if(isTutorial)
        {
            ActivateTip();
            isTutorial= false;
        }

    }

    public void ActivateTip()
    {
        actionActivate.Action();
    }


    private void OnTriggerEnter(Collider collider)
    {
        isOnBlender = true;
        
    }

    


    private void OnTriggerExit(Collider collider)
    {
        isOnBlender = false;
        blenderAnimator.SetBool("openBlender", false);

    }

    


    public void refreshBlender()
    {
        isOnBlender = false;
        fruitList[0] = ("");
        fruitList[1] = ("");
        fruitList[2] = ("");
        fruitsOnBlender = 0;
    }



}
