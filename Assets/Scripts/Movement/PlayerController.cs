using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    public Animator animator1;
    public float rtquaternion;

    

    public void onMove(InputAction.CallbackContext context)
    {
        
        move = context.ReadValue<Vector2>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        movePlayer();


        
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        animator1.SetBool("isWalking", false);

        if (movement != Vector3.zero)
        {
            animator1.SetBool("isWalking", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rtquaternion);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
