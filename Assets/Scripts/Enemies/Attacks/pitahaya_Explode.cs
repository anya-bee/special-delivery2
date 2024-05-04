using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitahaya_Explode : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform explosionObj;
    public Transform expLocation;
    public GameObject particlesPitahaya;
    void Start()
    {
        expLocation = Instantiate(explosionObj, expLocation.position, Quaternion.identity);
        particlesPitahaya = expLocation.gameObject;
        expLocation.gameObject.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        expLocation.position = new Vector3(this.transform.position.x, this.transform.position.y +2, this.transform.position.z);
    }


    public void explosion()
    {
        Script_AudioManager.instance.PlaySFX("dragoncito");
        expLocation.gameObject.SetActive(true);
        Debug.Log("a pitahaya exploded!!!!!! BOOOOOOM");
        

    }

    IEnumerator waitToExplode()
    {

        yield return new WaitForSeconds(1.1f);

    }



}
