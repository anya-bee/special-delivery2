using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public Vector3 originalPos;
    public Vector3 introPos;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public bool isInside;
    public GameObject player;
    [SerializeField] bool isTutorial;

    // This code helps the camera follow the player depending if the player is inside or outside the bus
    void Start()
    {
        target = null;
        isInside = true;
        originalPos = GetComponentInChildren<Transform>().position;
        introPos = new Vector3(originalPos.x, originalPos.y - 20, originalPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial) return;
        isInside = player.GetComponent<PlayerController>().isOnBus;
        if (isInside)
        {
            target = null;
            //gameObject.GetComponent<PlayerAttack>().playerSword.SetActive(false);
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
    /*private void OnTriggerEnter(Collider other)
    {
        float saveY;
        transform.position.y = saveY
    }*/





}
