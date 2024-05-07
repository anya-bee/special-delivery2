using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class powerUpTrigger : MonoBehaviour
{

    public Transform powerOrbInstance;
    public Transform orbSpawnPlace;
    public int randomOrb;
    public clientOrderUI clientOrderCode;
    public UnityEvent refreshBlender;
 

    [Header("Orb Types")]
    public List<Transform> orbTypeList;

    private void Start()
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
        if (randomOrb == 0)
        {
            Script_AudioManager.instance.PlayPlayerSFX("banana");

        }
        else if(randomOrb == 1)
        {
            Script_AudioManager.instance.PlayPlayerSFX("fruity");

        }
        else if (randomOrb == 2)
        {
            Script_AudioManager.instance.PlayPlayerSFX("coco");

        }




    }
}
