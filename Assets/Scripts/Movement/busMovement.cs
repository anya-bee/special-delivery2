using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class busMovement : MonoBehaviour
{

    public float speed;
    private Vector2 move;
    public float rtquaternion;


    public void OnMoveBus(InputValue context)
    {

        move = context.Get<Vector2>();
        Debug.Log(move);

    }


    void Update()
    {

        moveBus();



    }

    public void moveBus()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);


        if (movement != Vector3.zero)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rtquaternion);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
