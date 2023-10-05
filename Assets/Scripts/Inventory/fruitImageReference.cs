using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitImageReference : MonoBehaviour
{
    public static fruitImageReference Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public Transform prefabFruit;


    [Header("Fruit Sprites")]
    public Sprite lemonSprite;
    public Sprite limeSprite;
    public Sprite strawberrySprite;
    public Sprite pitahayaSprite;

    [Header("Material Color")]

    public Color32 strawberryColor;
    public Color32 limeColor;
    public Color32 lemonColor;
    public Color32 pitahayaColor; 


}
