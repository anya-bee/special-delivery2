using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_PTH_MNG : MonoBehaviour
{

    [Header("Pitahaya_Prefab")]
    public Transform pitahayaFN_PF;

    [Header("Spawn Places")]
    public List<PitahayaSpawnLocator> spawnLocations;

    [Header("Bomb Ranges")]
    public Vector2 rangeX;
    public Vector2 rangeY;
    public Vector2 rangeZ;


    // Start is called before the first frame update
    void Start()
    {
        invokeFruitBombs();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void randomSpawnPlaces(Transform t)
    {


    }

    public void invokeFruitBombs()
    {
        foreach (PitahayaSpawnLocator Spawn in spawnLocations)
        {

            Vector3 randomBombSpawn = new Vector3(Random.Range(rangeX.x , rangeX.y), Random.Range(rangeY.x, rangeY.y), Random.Range(rangeZ.x, rangeZ.y));
            Spawn.spawnLocation.position = randomBombSpawn;
            Spawn.currentBomb = Instantiate(pitahayaFN_PF, Spawn.spawnLocation.position, Quaternion.identity);
            
        }
    }

}

[System.Serializable]
public class PitahayaSpawnLocator
{
    public Transform spawnLocation;
    public Transform currentBomb;
    
}