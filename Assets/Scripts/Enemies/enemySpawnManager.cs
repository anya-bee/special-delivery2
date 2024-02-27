using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SpawnLocator
{
    public int enemyNumber;
    public Transform currentEnemy;
    public Transform spawnLocation;
    public bool enemyAlive = false;
}

public class enemySpawnManager : MonoBehaviour
{

    [Header("Enemy List ")]
    public List<Transform> enemyTypeList;
    public bool newEnemy;

    [Header("Enemies per Level")]
    [SerializeField] private int enemiesPerLevel;
    [SerializeField] private int enemyCount;

    [Header("Spawn Places")]
    public List<SpawnLocator> spawnLocations;


    void Start()
    {
        enemiesPerLevel = enemyTypeList.Count;
        enemyCount = 0;
        foreach (SpawnLocator Spawn in spawnLocations)
        {
            Spawn.enemyAlive = true;



            Spawn.currentEnemy = Instantiate(enemyTypeList[enemyCount], Spawn.spawnLocation.position, Quaternion.identity);
            if (enemyCount < (enemyTypeList.Count - 1))
            {
                enemyCount++;
            }
            else
            {
                enemyCount = 0;
            }
        }
        enemyCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        foreach ( SpawnLocator Spawn in spawnLocations)
        {
            


            if( Spawn.enemyAlive == false)
            {
                Spawn.enemyAlive = true;
                
                Spawn.enemyNumber = enemyCount;

                
                Spawn.currentEnemy = Instantiate(enemyTypeList[Spawn.enemyNumber], Spawn.spawnLocation.position, Quaternion.identity);
                

                //Spawn.currentEnemy = Spawn.spawnLocation.GetComponentInChildren<EnemyHealth>().gameObject;


            }

            if (Spawn.currentEnemy.GetComponent<EnemyHealth>().isDead == true)
            {
                if (enemyCount < (enemyTypeList.Count - 1))
                {
                    enemyCount++;
                }
                else
                {
                    enemyCount = 0;
                }
                
                Spawn.currentEnemy.GetComponent<EnemyHealth>().dieAction();


                Spawn.enemyAlive = false;
            }
        }
    }


    



    IEnumerator respawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        newEnemy = true;

    }

}
