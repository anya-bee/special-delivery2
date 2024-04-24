using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpTrigger : MonoBehaviour
{

    public Transform powerOrbInstance;
    public Transform orbSpawnPlace;
    public int randomOrb;
    public clientOrderUI clientOrderCode;

    public List<string> fruitPowerOrb;

    [Header("Orb Types")]
    public List<Transform> orbTypeList;

    private void Start()
    {

        fruitPowerOrb.Add("");
        fruitPowerOrb.Add("");
        fruitPowerOrb.Add("");
        clientOrderCode.blankFruitsIcon();

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void OrbSpawn()
    {
        randomOrb = Random.Range(0, 3);
        powerOrbInstance = Instantiate(orbTypeList[randomOrb], orbSpawnPlace.position, Quaternion.identity);


    }
}
