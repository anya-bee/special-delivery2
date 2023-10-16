using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class juiceGlass : MonoBehaviour
{

    public Transform prefabJuice;
    public string juiceType;
    public List<string> glassOrder;
    public List<string> newOrder;
    public Renderer fruitrender1;
    public Color juiceColor;

    public Transform newGuide;

    private void Awake()
    {
        
    }

    private void Start()
    {
        juiceColor = GetColor();
        fruitrender1.material.SetColor("_BaseColor", juiceColor);
        newGuide = GameObject.FindWithTag("glassHolder").transform;
        

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





    public void carryJuice()
    {
       
            transform.SetParent(newGuide);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = new Vector3(0.4f,0.5f,0.4f);
        
    }


    public void leaveJuice(Transform t1)
    {
        transform.SetParent(t1);
        transform.localPosition = new Vector3(0,1.5f,0);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(0.4f, 0.5f, 0.4f);
    }
            







}
