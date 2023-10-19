using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitDrops : MonoBehaviour
{


     public MeshFilter prefabBaseMesh;

    public static fruitDrops SpawnFruitDrops(Vector3 position, Fruits fruit2)
    {
        Transform transform = Instantiate(fruitImageReference.Instance.prefabFruit, position, Quaternion.identity);
        
        fruitDrops fruitdrop1 = transform.GetComponent<fruitDrops>();
        fruitdrop1.SetFruit(fruit2);
        
        return fruitdrop1;
    }

    private Fruits fruit;
    private Renderer fruitrender1;
    public GameObject thisFruit;


    private void Awake()
    {
        thisFruit = this.gameObject;
        fruitrender1 = thisFruit.GetComponent<Renderer>();
       
    }

    public void SetFruit(Fruits f1)
    {
        this.fruit = f1;
        prefabBaseMesh.mesh = f1.getMesh();
        fruitrender1.material.SetColor("_BaseColor", f1.GetColor());
        fruitrender1.material = f1.getMaterial();
    }

    public Fruits getFruit()
    {
        return fruit;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }


}
