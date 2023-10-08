using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory2 : MonoBehaviour

{

    private Inventory inventory;

    [SerializeField] private UI_Inventory2 uiInventory; 

    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        Spawn_Enemy1.SpawnEnemy(new Vector3(7, 0), new Enemy_1 { enemyType = Enemy_1.EnemyType.Lemon_Enemy, amount = 1 });
        Spawn_Enemy1.SpawnEnemy(new Vector3(-5, 0), new Enemy_1 { enemyType = Enemy_1.EnemyType.Pitahaya_Enemy, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(5, 0), new Fruits { fruitType = Fruits.FruitTypes.Lime, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(0, 1), new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(1, 0), new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(3, 0,-2), new Fruits { fruitType = Fruits.FruitTypes.Pitahaya, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(4, 0, -4), new Fruits { fruitType = Fruits.FruitTypes.Pitahaya, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(6, 0,3), new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
        fruitDrops.SpawnFruitDrops(new Vector3(-8, 0), new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
    }

    private void OnTriggerEnter(Collider collider)
    {
        fruitDrops fruitDrop1 = collider.GetComponent<fruitDrops>();
        if ( fruitDrop1 != null)
        {
            //touching item
            inventory.addFruit(fruitDrop1.getFruit());
            fruitDrop1.DestroySelf();


        }
    }


    /*private void UseItem(Fruits f)
    {
        switch (f.fruitType)
        {
            case Fruits.FruitTypes.Lemon:
                inventory.removeFruits(new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
                break;
            case Fruits.FruitTypes.Lime:
                inventory.removeFruits(new Fruits { fruitType = Fruits.FruitTypes.Lime, amount = 1 });
                break;
            case Fruits.FruitTypes.Strawberry:
                inventory.removeFruits(new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
                break;
            case Fruits.FruitTypes.Pitahaya:
                inventory.removeFruits(new Fruits { fruitType = Fruits.FruitTypes.Pitahaya, amount = 1 });
                break;

        }
    }*/



}
