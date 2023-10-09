using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blender_Inventory : MonoBehaviour
{

    public bool isOnBlender = false;
    public string[] fruitsArray = new string[3];
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

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void refreshBlender()
    {
        isOnBlender = false;
        fruitList.Clear();
        fruitsOnBlender = 0;
    }



}
