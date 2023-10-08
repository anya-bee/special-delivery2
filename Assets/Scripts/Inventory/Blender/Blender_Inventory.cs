using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender_Inventory : MonoBehaviour
{
    public Inventory blenderInventory;
    public List<string> stringList;
    public bool isOnBlender = false;
    

    private void Start()
    {
        blenderInventory = new Inventory();
        
    }

    private void Update()
    {
        foreach (Fruits f in blenderInventory.getFruitsList())
        {
            if (stringList.Count < 3)
            {
                stringList.Add(f.GetString()); break;
            }
            
        }

    }



}
