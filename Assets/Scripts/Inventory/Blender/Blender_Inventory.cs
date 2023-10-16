using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blender_Inventory : MonoBehaviour
{

    public bool isOnBlender = false;
    public List<string> fruitList;
    public int fruitsOnBlender;
    public Animator blenderAnimator;


    [Header("thisGameObject")]
    public GameObject blender;
    

    private void Start()
    {
        isOnBlender = false;
        blender = this.gameObject;
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
        if (fruitsOnBlender == 3)
        {
            blenderAnimator.SetBool("openBlender", false);
            GetComponentInChildren<juiceGenerator>().SetJuice(fruitList);
            fruitsOnBlender = 0;
            
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        isOnBlender = true;
        
    }

    


    private void OnTriggerExit(Collider collider)
    {
        isOnBlender = false;
        
    }

    


    private void refreshBlender()
    {
        isOnBlender = false;
        fruitList.Clear();
        fruitsOnBlender = 0;
    }



}
