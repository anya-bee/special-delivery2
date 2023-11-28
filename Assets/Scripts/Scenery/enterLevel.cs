using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enterLevel : MonoBehaviour
{

    public GameObject lvlPopUp;
    public GameObject startButton;
    public Animator logoAnimator;


    // Start is called before the first frame update
    void Start()
    {
        lvlPopUp.SetActive(false);
        startButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        lvlPopUp.SetActive(true);
        startButton.SetActive(true);
        lvlPopUp.GetComponent<starScoreDisplay>().starsCoroutine();
    }

    private void OnTriggerExit(Collider other)
    {
        lvlPopUp.SetActive(false);
        startButton.SetActive(false);

    }


}
