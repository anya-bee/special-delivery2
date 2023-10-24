using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public Vector3 originalPos;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public bool isInside;
    public GameObject player;

    // This code helps the camera follow the player depending if the player is inside or outside the bus
    void Start()
    {
        target = null;
        isInside = true;
        originalPos = GetComponentInChildren<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        isInside = player.GetComponent<PlayerController>().isOnBus;
        if (isInside)
        {
            target = null;
        }
        else
        {
            target = player.transform;
        }

        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            
        }
        if(target == null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, originalPos, ref velocity, smoothTime);
        }


    }


    

    
}
