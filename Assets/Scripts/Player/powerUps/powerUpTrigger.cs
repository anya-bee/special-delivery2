using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpTrigger : MonoBehaviour
{

    public Transform powerOrbInstance;
    public Transform orbSpawnPlace;
    public int randomOrb;

    [Header("Orb Types")]
    public List<Transform> orbTypeList;

    // Start is called before the first frame update
    void Start()
    {
        
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
