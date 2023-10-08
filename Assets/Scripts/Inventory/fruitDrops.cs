using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitDrops : MonoBehaviour
{

    public static fruitDrops SpawnFruitDrops(Vector3 position, Fruits fruit2)
    {
        Transform transform = Instantiate(fruitImageReference.Instance.prefabFruit, position, Quaternion.identity);

        fruitDrops fruitdrop1 = transform.GetComponent<fruitDrops>();
        fruitdrop1.SetFruit(fruit2);

        return fruitdrop1;
    }

    private Fruits fruit;
    private Renderer fruitrender1;
    public GameObject mesh;


    private void Awake()
    {
        mesh = this.gameObject;
        fruitrender1 = mesh.GetComponent<Renderer>();
       
    }

    public void SetFruit(Fruits f1)
    {
        this.fruit = f1;
        fruitrender1.material.SetColor("_BaseColor", f1.GetColor());
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
