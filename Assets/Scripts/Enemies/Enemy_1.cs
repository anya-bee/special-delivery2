using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 
{
    public enum EnemyType
    {
        Lime_Enemy,
        Lemon_Enemy,
        Strawberry_Enemy,
        Pitahaya_Enemy,
    }

    public EnemyType enemyType;
    public int amount;


    public Color GetColor()
    {
        switch (enemyType)
        {
            default:

            case EnemyType.Lime_Enemy: return Manager_Enemy1.Instance.limeColor;
            case EnemyType.Strawberry_Enemy: return Manager_Enemy1.Instance.strawberryColor;
            case EnemyType.Lemon_Enemy: return Manager_Enemy1.Instance.lemonColor;
            case EnemyType.Pitahaya_Enemy: return Manager_Enemy1.Instance.pitahayaColor;

        }
    }

    public string GetString()
    {
        switch (enemyType)
        {
            default:

            case EnemyType.Lime_Enemy: return Manager_Enemy1.Instance.lime_string;
            case EnemyType.Strawberry_Enemy: return Manager_Enemy1.Instance.strawberry_string;
            case EnemyType.Lemon_Enemy: return Manager_Enemy1.Instance.lemon_string;
            case EnemyType.Pitahaya_Enemy: return Manager_Enemy1.Instance.pitahaya_string;

        }
    }





}
