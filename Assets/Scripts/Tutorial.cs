using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{

    public GameObject uiBox;
    public TextMeshProUGUI dialogue;
    public GameObject cameraPos;
    public Transform targetPosition;
    private Vector3 velocity = Vector3.zero;
    public int dialogueCount= 0;
    public CameraMovement player;

    // Start is called before the first frame update
    void Start()
    {
        uiBox.SetActive(true);
        StartCoroutine(dialogue1());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator dialogue1()
    {
        yield return new WaitForSeconds(4f);
        dialogue.text = "There’s wild fruit monsters out there. I must defeat them to make smoothies.";
        yield return new WaitForSeconds(4f);
        dialogue.text = "Grandma said “ Right Click to attack enemies”";
        yield return new WaitForSeconds(4f);
        uiBox.SetActive(false);
        dialogueCount = 2;
    }

    IEnumerator dialogue2()
    {
        
        uiBox.SetActive(true);
        dialogue.text = "Now let’s go to the blender. It's important to put the fruits in the right order. ";
        
        yield return new WaitForSeconds(4f);

        dialogue.text = "It 's ready ! I can serve the smoothie now ! Press SPACE to grab and deliver smoothies";
        dialogueCount = 3;


    }

    IEnumerator dialogue3()
    {

        
        
        yield return new WaitForSeconds(6f);
        dialogue.text = "A happy client, and more to come ! I should go and gather more fruits by defeating enemies. ";
        yield return new WaitForSeconds(6f);
        uiBox.SetActive(false);
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (dialogueCount == 2)
        {
            StartCoroutine(dialogue2());
        }
        else if (dialogueCount == 3)
        {
            StartCoroutine(dialogue3());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
       if (dialogueCount == 3)
        {
            StartCoroutine(dialogue3());
        }
    }

}
