using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpTrigger : MonoBehaviour
{

    public Transform powerOrbInstance;
    public Transform orbSpawnPlace;
    public int randomOrb;
    public clientOrderUI clientOrderCode;

 

    [Header("Orb Types")]
    public List<Transform> orbTypeList;

    private void Start()
    {



    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public string OrbSpawn()
    {
        randomOrb = Random.Range(0, 3);

        switch (randomOrb)
        {
            default:
            case 0: return "bananaShoesMode";
            case 1: return "cocoShieldMode";
            case 2: return "fruitySwordMode";


        }

        

    }
}
