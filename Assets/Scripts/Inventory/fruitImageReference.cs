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

    [Header("Fruit Name String")]

    public string strawberry_string = "Strawberry_Fruit";
    public string lemon_string = "Lemon_Fruit";
    public string lime_string = "Lime_Fruit";
    public string pitahaya_string = "Pitahaya_Fruit";

    [Header("Fruit Meshes")]

    public Mesh strawberryMesh;
    public Mesh lemonMesh;
    public Mesh limeMesh;
    public Mesh pitahayaMesh;

    [Header("Fruit Textures")]

    public Material strawberryTXT;
    public Material lemonTXT;
    public Material limeTXT;
    public Material pitahayaTXT;


}
