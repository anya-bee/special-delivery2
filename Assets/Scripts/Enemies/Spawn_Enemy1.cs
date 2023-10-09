using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy1 : MonoBehaviour
{

    public static Spawn_Enemy1 SpawnEnemy(Vector3 position, Enemy_1 enemy2)
    {


        Transform transform = Instantiate(Manager_Enemy1.Instance.prefabEnemy, position, Quaternion.identity);

        Spawn_Enemy1 enemySpawn = transform.GetComponent<Spawn_Enemy1>();
        enemySpawn.SetEnemy(enemy2);

        return enemySpawn;
    }


    public Enemy_1 enemy1;
    private Renderer enemyrender1;
    public GameObject mesh;
    public Mesh enemyMesh;


    private void Awake()
    {
        mesh = this.gameObject;
        enemyMesh = mesh.GetComponent<Mesh>();
        enemyrender1 = mesh.GetComponent<Renderer>();

    }

    public void SetEnemy(Enemy_1 e1)
    {
        this.enemy1 = e1;
        enemyrender1.material.SetColor("_BaseColor", e1.GetColor());
    }

    public Enemy_1 getEnemy()
    {
        return enemy1;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }



}
