using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_Lemon_Bomb : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroySelf());
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }


    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(6);

        Destroy(this.gameObject);
    }
}
