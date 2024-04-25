using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMovement : MonoBehaviour
{
    public Animator busAnimator;
    public Image busImage;
    public int station = 0;

    void Start()
    {
        busAnimator = busImage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //go to the park
        if (Input.GetKeyDown(KeyCode.D) && station == 0)
        {
            station = 1;
            Debug.Log("once");
            busAnimator.SetTrigger("Forward");
            
        }
        else if (Input.GetKeyDown(KeyCode.D) && station == 1)
        {
            busAnimator.SetTrigger("Forward2");
            station = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D) && station == 2)
        {
            busAnimator.SetTrigger("Forward3");
            station = 3;
        }
        //return to city
        
        
        if ((Input.GetKeyDown(KeyCode.A) && station == 3))
        {
            busAnimator.SetTrigger("Backwards3");
            station = 2;
        }
        else if ((Input.GetKeyDown(KeyCode.A) && station == 2))
        {
            busAnimator.SetTrigger("Backwards2");
            station = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.A) && station == 1))
        {
            busAnimator.SetTrigger("Backwards");
            station = 0;
        }
        // return to park


        //return to jungle

    }
}

