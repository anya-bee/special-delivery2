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


    [Header("juiceGenerator")]
    public Transform prefabJuice;
    public string juiceType;
    private Renderer fruitrender1;
    public GameObject blender;
    public Transform newLocation;
    

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
            fruitsOnBlender = 0;
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

    }



    private void OnTriggerEnter(Collider collider)
    {
        isOnBlender = true;
        
    }

    


    private void OnTriggerExit(Collider collider)
    {
        isOnBlender = false;
        
    }

    


    public void refreshBlender()
    {
        isOnBlender = false;
        fruitList.Clear();
        fruitsOnBlender = 0;
    }



}
