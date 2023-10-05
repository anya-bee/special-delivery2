using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory; 

    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);


        fruitDrops.SpawnFruitDrops(new Vector3(5, 5), new Fruits { fruitType = Fruits.FruitTypes.Lime, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(0, 1), new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(1, 0), new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(3, 0,-2), new Fruits { fruitType = Fruits.FruitTypes.Pitahaya, amount = 1 });
    }

    
}
