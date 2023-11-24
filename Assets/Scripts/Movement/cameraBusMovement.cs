using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBusMovement : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;


    // This code helps the camera follow the player depending if the player is inside or outside the bus
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }



    }
}
