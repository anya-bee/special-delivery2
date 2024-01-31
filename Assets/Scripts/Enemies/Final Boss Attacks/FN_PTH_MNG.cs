using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_PTH_MNG : MonoBehaviour
{

    [Header("Pitahaya_Prefab")]
    public Transform pitahayaFN_PF;

    [Header("Spawn Places")]
    public List<PitahayaSpawnLocator> spawnLocations;
    public float minorRange, mayorRange;

    public Vector3 newLocPosition;

    // Start is called before the first frame update
    void Start()
    {
        invokeFruitBombs();
        newLocPosition = new Vector3(Random.Range(minorRange, mayorRange), Random.Range(minorRange, mayorRange), Random.Range(minorRange, mayorRange));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*public void randomSpawnPlaces(Transform t)
    {
        
        
        if (t.position == newLocPosition)
        {
            newLocPosition = new Vector3(Random.Range(minorRange, mayorRange), Random.Range(minorRange, mayorRange), Random.Range(minorRange, mayorRange));
        }
    }*/

    public void invokeFruitBombs()
    {
        foreach (PitahayaSpawnLocator Spawn in spawnLocations)
        {
            

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
