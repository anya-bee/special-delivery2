using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FN_Lemon_Bomb : MonoBehaviour
{
    public string bossLemon = "bossLemon";
    public float speed;
    public float sightRange;
    public LayerMask swordLayer;
    public bool checkSword;
    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroyAfteraWhile());
        GetComponent<Rigidbody>().velocity = direction.right * speed;

        
        if (checkSword == true)
        {
            GetComponent<Rigidbody>().velocity = -direction.right * speed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(new Vector3(transform.position.x + 0.03f, transform.position.y + 0.51f, transform.position.z + 0.19f), sightRange);

    }

    public void destroySelf()
    {
        

        Destroy(this.gameObject);
    }

    IEnumerator destroyAfteraWhile()
    {

        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
}
