using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //ATRIBUTOS
    public float currentLifeAmount;
    public float maxLifeAmount;
    public bool isDead;

    [Header("Enemy_Info")]

    public Enemy_1 thisEnemy;
    public string enemyString;


    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
        //thisEnemy = this.gameObject.GetComponent<Spawn_Enemy1>().enemy1;
        //enemyString = thisEnemy.GetString();
    }

    private void Update()
    {
        if (currentLifeAmount <= 0)
        {
            Die();
        }
    }

    //METODOS
    public void Damage(float amount)
    {
        currentLifeAmount -= amount;

       
    }

    public void Heal(float amount)
    {
        currentLifeAmount += amount;

        if (currentLifeAmount > maxLifeAmount)
        {
            currentLifeAmount = maxLifeAmount;
        }
    }

    protected void Die()
    {
        isDead = true;
        spawnFruit();
        Destroy(this.gameObject);
    }



    private void spawnFruit()
    {
        
        
        if ( enemyString == "Strawberry_Enemy")
        {
            fruitDrops.SpawnFruitDrops(new Vector3(this.gameObject.transform.position.x, 5, this.gameObject.transform.position.z), new Fruits { fruitType = Fruits.FruitTypes.Strawberry, amount = 1 });
        }
        else if (enemyString == "Lemon_Enemy")
        {
            fruitDrops.SpawnFruitDrops(new Vector3(this.gameObject.transform.position.x, 5, this.gameObject.transform.position.z), new Fruits { fruitType = Fruits.FruitTypes.Lemon, amount = 1 });
        }
        else if (enemyString == "Lime_Enemy")
        {
            fruitDrops.SpawnFruitDrops(new Vector3(this.gameObject.transform.position.x, 5, this.gameObject.transform.position.z), new Fruits { fruitType = Fruits.FruitTypes.Lime, amount = 1 });
        }
        else if (enemyString == "Pitahaya_Enemy")
        {
            fruitDrops.SpawnFruitDrops(new Vector3(this.gameObject.transform.position.x, 5, this.gameObject.transform.position.z), new Fruits { fruitType = Fruits.FruitTypes.Pitahaya, amount = 1 });
        }


    }

}
