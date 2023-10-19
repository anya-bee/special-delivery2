using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits 
{
    public enum FruitTypes
    {
        Lime,
        Lemon,
        Strawberry,
        Pitahaya,
    }

    public FruitTypes fruitType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (fruitType)
        {
            default:
            case FruitTypes.Lemon: return fruitImageReference.Instance.lemonSprite;
            case FruitTypes.Lime: return fruitImageReference.Instance.limeSprite;
            case FruitTypes.Strawberry: return fruitImageReference.Instance.strawberrySprite;
            case FruitTypes.Pitahaya: return fruitImageReference.Instance.pitahayaSprite;
        }
    }

    public Color GetColor()
    {
        switch (fruitType)
        {
            default:
            
            case FruitTypes.Lime: return fruitImageReference.Instance.limeColor;
            case FruitTypes.Strawberry: return fruitImageReference.Instance.strawberryColor;
            case FruitTypes.Lemon: return fruitImageReference.Instance.lemonColor;
            case FruitTypes.Pitahaya: return fruitImageReference.Instance.pitahayaColor;

        }
    }

    public Mesh getMesh()
    {
        switch (fruitType)
        {
            default:

            case FruitTypes.Lime: return fruitImageReference.Instance.limeMesh;
            case FruitTypes.Strawberry: return fruitImageReference.Instance.strawberryMesh;
            case FruitTypes.Lemon: return fruitImageReference.Instance.lemonMesh;
            case FruitTypes.Pitahaya: return fruitImageReference.Instance.pitahayaMesh;

        }
    }

    public Material getMaterial()
    {
        switch (fruitType)
        {
            default:

            case FruitTypes.Lime: return fruitImageReference.Instance.limeTXT;
            case FruitTypes.Strawberry: return fruitImageReference.Instance.strawberryTXT;
            case FruitTypes.Lemon: return fruitImageReference.Instance.lemonTXT;
            case FruitTypes.Pitahaya: return fruitImageReference.Instance.pitahayaTXT;

        }
    }






    public bool isStackable()
    {
        switch (fruitType)
        {
            default:
            case FruitTypes.Lemon:
            case FruitTypes.Lime:
            case FruitTypes.Strawberry:
            case FruitTypes.Pitahaya:
                return true;

        }
    }


    public string GetString()
    {
        switch (fruitType)
        {
            default:

            case FruitTypes.Lime: return fruitImageReference.Instance.lime_string; 
            case FruitTypes.Strawberry: return fruitImageReference.Instance.strawberry_string;
            case FruitTypes.Lemon: return fruitImageReference.Instance.lemon_string;
            case FruitTypes.Pitahaya: return fruitImageReference.Instance.pitahaya_string;
            
        }
    }

}
