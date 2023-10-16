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

    [Header("Taking Orders")]
    public float radius;
    public Collider[] glassHitColliders = new Collider[1];
    public Collider[] trayCollider = new Collider[1];
    public LayerMask glassLayer;
    public LayerMask trayLayer;
    public InputManager glassTakeout;
    private InputAction takeglass;
    public bool carryingOrder = false;
    public GameObject currentGlass;

    private void Awake()
    {
        glassTakeout = new InputManager();
    }

    private void OnEnable()
    {
        takeglass = glassTakeout.Player.TakeGlass;
        takeglass.Enable();
        takeglass.performed += takeGlass;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        
        move = context.ReadValue<Vector2>();
        
    }

    public void takeGlass(InputAction.CallbackContext context)
    {
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, glassHitColliders, glassLayer);
        if (numColliders2 == 1)
        {
            currentGlass = glassHitColliders[0].gameObject;
            currentGlass.GetComponent<juiceGlass>().carryJuice();
            carryingOrder = true;
        }

        int numColliders3 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, trayCollider, trayLayer);
        if (numColliders3 == 1)
        {
            carryingOrder = false;
            trayCollider[0].gameObject.GetComponent<orderChecked>().glassIsOnTray = true;
            currentGlass.GetComponent<juiceGlass>().leaveJuice(trayCollider[0].transform);
            trayCollider[0] = null;
            currentGlass = null;
            glassHitColliders[0] = null;

        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
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
