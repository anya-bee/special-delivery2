using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Enemy1 : MonoBehaviour
{
    public static Manager_Enemy1 Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform prefabEnemy;

    [Header("Material Color")]

    public Color32 strawberryColor;
    public Color32 limeColor;
    public Color32 lemonColor;
    public Color32 pitahayaColor;

    [Header("Enemy Name String")]

    public string strawberry_string = "Strawberry_Enemy";
    public string lemon_string = "Lemon_Enemy";
    public string lime_string = "Lime_Enemy";
    public string pitahaya_string = "Pitahaya_Enemy";



}
