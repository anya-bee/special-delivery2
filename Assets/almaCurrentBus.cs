using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class almaCurrentBus : MonoBehaviour
{
    public LayerMask enemyLayer;
    public  int currentMaterial;
    public bool bossStage;

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


    private void OnTriggerEnter(Collider other)
    {
        if (bossStage == true)
        {
            Destroy(other.gameObject);
        }
    }
}
