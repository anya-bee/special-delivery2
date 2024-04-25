using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_PTH_MNG : MonoBehaviour
{

    [Header("Prefab")]
    public Transform pitahayaFN_PF;
    public string fruitType;
    public int noStrawberry;

    [Header("Spawn Places")]
    public List<PitahayaSpawnLocator> spawnLocations;

    [Header("Bomb Ranges")]
    public Vector2 rangeX;
    public Vector2 rangeY;
    public Vector2 rangeZ;


    // Start is called before the first frame update
    void Start()
    {
        foreach (PitahayaSpawnLocator Spawn in spawnLocations)
        {

            Spawn.isDead = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }



    public void invokeFruitBombs()
    {
        foreach (PitahayaSpawnLocator Spawn in spawnLocations)
        {

            Vector3 randomBombSpawn = new Vector3(Random.Range(rangeX.x , rangeX.y), Random.Range(rangeY.x, rangeY.y), Random.Range(rangeZ.x, rangeZ.y));
            Spawn.spawnLocation.position = randomBombSpawn;
            Spawn.currentBomb = Instantiate(pitahayaFN_PF, Spawn.spawnLocation.position, Quaternion.identity);
            if (Spawn.currentBomb == null)
            {
                Spawn.isDead = true;
            }
        }
    }

    public void checkStrawberry(Animator anim1)
    {
        
       
        if (noStrawberry == 3)
        {
            anim1.SetLayerWeight(1, 1f);
        }
    }

    public void invokeCitrics(Transform place)
    {
        
        var citricBomb = Instantiate(pitahayaFN_PF, place.position , Quaternion.identity);
        citricBomb.GetComponent<FN_Lemon_Bomb>().direction = place;
        
    }


}

[System.Serializable]
public class PitahayaSpawnLocator
{
    public Transform spawnLocation;
    public Transform currentBomb;
    public bool isDead;
}
