using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceGlass : MonoBehaviour
{

    public Transform prefabJuice;
    public string juiceType;
    public List<string> glassOrder;
    public Renderer fruitrender1;
    public Color juiceColor;

    private void Start()
    {
        juiceColor = GetColor();
        fruitrender1.material.SetColor("_BaseColor", juiceColor);
    }

    public Color GetColor()
    {
        switch (juiceType)
        {
            default:

            case "Lime_Fruit": return fruitImageReference.Instance.limeColor;
            case "Strawberry_Fruit": return fruitImageReference.Instance.strawberryColor;
            case "Lemon_Fruit": return fruitImageReference.Instance.lemonColor;
            case "Pitahaya_Fruit": return fruitImageReference.Instance.pitahayaColor;

        }
    }








}
