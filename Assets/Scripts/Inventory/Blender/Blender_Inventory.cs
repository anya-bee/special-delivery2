using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blender_Inventory : MonoBehaviour
{

    public bool isOnBlender = false;
    public List<string> fruitList;
    public int fruitsOnBlender;
    

    private void Start()
    {
        isOnBlender = false;
        
    }

    private void refreshSmoothie()
    {
        fruitList.Clear();
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
