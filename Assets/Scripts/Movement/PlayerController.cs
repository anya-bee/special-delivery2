using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float originalSpeed;
    private Vector2 move;
    public Animator animator1;
    public float rtquaternion;
    public bool isOnBus;
    private InputAction newMovePlayer;

    [Header("Status Ailments")]
    public bool dizzyState = false;
    public bool stunnedState = false;
    public float stunnedVar;
    private bool first=false;

    [Header("Taking Orders")]
    public float radius;
    public Collider[] glassHitColliders = new Collider[1];
    public Collider[] trayCollider = new Collider[1];
    public LayerMask glassLayer;
    public LayerMask trayLayer;
    public InputManager glassTakeout;
    private InputAction takeglass;
    private InputAction attack;
    public bool carryingOrder = false;
    public GameObject currentGlass;

    private void Awake()
    {

        originalSpeed = speed;
        
    }

    /*private void OnEnable()
    {
        
        attack.Enable();
        attack.performed += attackAction;
        takeglass.Enable();
        takeglass.performed += takeGlass;
    }*/

    public void OnMove(InputValue context)
    {

        move = context.Get<Vector2>();
        //Debug.Log(move);

    }

    public void OnAttack()
    {
        
        if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().isOnBus == false)
        {

            animator1.SetTrigger("IsAttacking");
            

            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().attackState();
            //Script_AudioManager.instance.PlaySFX("Stab");

        }
        
    }

    public void OnTakeGlass()
    {
        int numColliders2 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, glassHitColliders, glassLayer);
        if (numColliders2 == 1)
        {
            currentGlass = glassHitColliders[0].gameObject;
            currentGlass.GetComponent<juiceGlass>().carryJuice();
            carryingOrder = true;
            GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().refreshBlender();
        }


        int numColliders3 = Physics.OverlapSphereNonAlloc(this.transform.position, radius, trayCollider, trayLayer);
        if (numColliders3 == 1)
        {
            carryingOrder = false;
            trayCollider[0].gameObject.GetComponent<orderChecked>().glassIsOnTray = true;
            Script_AudioManager.instance.PlaySFX("Ding");
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


    // Update is called once per frame
    void Update()
    {
        
        movePlayer();


        
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        animator1.SetBool("isWalking", false);

        if ( stunnedState == true)
        {
            movement =  new Vector3(0f, 0f, 0f);
            
        }
        else if ( stunnedState == false)
        {
            movement = new Vector3(move.x, 0f, move.y);
        }
        
        

        if (movement != Vector3.zero)
        {
            animator1.SetBool("isWalking", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rtquaternion);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void StunnedEffect()
    {

        speed = 0;
        GetComponent<Animator>().SetTrigger("isStunned");
        //GetComponent<Rigidbody>().velocity = transform.forward * 100f;
        GetComponent<PlayerHealth>().Damage(1);
        GetComponent<Animator>().SetLayerWeight(1, 1f);
        StartCoroutine(stunnedTime());
    }
    IEnumerator stunnedTime()
    {

        yield return new WaitForSeconds(stunnedVar);
        GetComponent<Animator>().SetTrigger("finishStun");
        GetComponent<Animator>().SetLayerWeight(1, 0f);
        stunnedState = false;
        speed = originalSpeed;
        //GetComponent<PlayerController>().speed = orgSpeed;
    }

    public void startCoroutineForHits()
    {
        StartCoroutine(hitTaken());
    }

    IEnumerator hitTaken()
    {
        
           GetComponent<Animator>().SetLayerWeight(1, 1f);
           yield return new WaitForSeconds(2f);
           GetComponent<Animator>().SetLayerWeight(1, 0f);

        
    }

}
