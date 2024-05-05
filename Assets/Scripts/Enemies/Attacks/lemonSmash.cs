using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class lemonSmash : MonoBehaviour
{
    [Header("Status Ailments")]
    public float stunnedTimeRecover;
    private bool first = false;
    public GameObject player;

    [Header("VFX Attack")]
    public VisualEffect darkLines;
    public ParticleSystem stars;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        stars.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stunPlayer()
    {
        if (first == false)
        {
            
            player.GetComponent<PlayerController>().stunnedState = true;
            player.transform.LookAt(transform);
            darkLines.Play();
            stars.gameObject.SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Damage(1);
            player.GetComponent<PlayerController>().StunnedEffect();
            
            first = true;

        }
        
    }

    IEnumerator stunnedTime()
    {

        yield return new WaitForSeconds(stunnedTimeRecover);
        first= false;
    }
}
