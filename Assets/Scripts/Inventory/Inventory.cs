using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    public event EventHandler onFruitListChanged;
    [SerializeField]private List<Fruits> fruitsList;
    public int fruitAmount = 0;

    public Inventory()
    {
        fruitsList = new List<Fruits>();
        //addFruit(new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
        //addFruit(new Fruits { fruitType = Fruits.FruitTypes.Lime, amount = 1 });
        //addFruit(new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
        Debug.Log(fruitsList.Count);
    }


    public void addFruit(Fruits f)
    {
        if (f.isStackable())
        {
            bool fruitInInventory = false;
            foreach (Fruits inventoryFruit in fruitsList)
            {
                if (inventoryFruit.fruitType == f.fruitType)
                {
                    inventoryFruit.amount += f.amount;
                    fruitInInventory = true;
                }
            }
            if (!fruitInInventory)
            {
                fruitsList.Add(f);
            }
        }
        else
        {
            fruitsList.Add(f);
        }
        onFruitListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void addToBlender(Fruits f)
    {
        if (f.isStackable())
        {
            bool fruitInInventory = false;
            
            if (!fruitInInventory)
            {
                fruitsList.Add(f);
                
            }
            
        }
        
        onFruitListChanged?.Invoke(this, EventArgs.Empty);

    }


    public void removeFruits(Fruits f)
    {
        if (f.isStackable())
        {

            //Fruits fruitOnInventory = null;
            foreach (Fruits inventoryFruit in fruitsList)
            {
                if (inventoryFruit.fruitType == f.fruitType)
                {
                    
                    inventoryFruit.amount -= 1;

                    if (f.amount == 0)
                    {
                        fruitsList.Remove(f);
                        break;
                    }
                }
            }
            /*
            if (fruitOnInventory != null && fruitOnInventory.amount <= 0)
            {
                fruitsList.Remove(fruitOnInventory);
                
            }
            

            else
            {
                fruitsList.Remove(f);
            }*/
        }
        
        onFruitListChanged?.Invoke(this, EventArgs.Empty);
    }


    


    public List<Fruits> getFruitsList()
    {
        return fruitsList;
    }

}
