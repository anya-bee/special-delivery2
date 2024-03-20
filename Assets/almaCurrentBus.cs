using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class almaCurrentBus : MonoBehaviour
{

    public  int currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = storeManagement.currentBusMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial = storeManagement.currentBusMaterial;
    }
}
