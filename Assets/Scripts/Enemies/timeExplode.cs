using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeExplode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteParticles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator deleteParticles()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
