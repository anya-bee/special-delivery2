using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clientOrderUI : MonoBehaviour
{

    public List<string> clientOrder;

    public GameObject assignedTray;
    public Image[] orderSprite;
    public bool boolNotebook = false;
    public bool isBossBattle;
    public Sprite blankFruit;

    public Animator notebookAnimator;

    [Header("Time For Orders")]
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        clientOrder.Add("");
        clientOrder.Add("");
        clientOrder.Add("");
        notebookAnimator.SetBool("orderReady", true);
        blankFruitsIcon();
        
    }
    public void blankFruitsIcon()
    {
        for (int i = 0; i < orderSprite.Length; i++)
        {
            orderSprite[i].sprite = blankFruit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossBattle == true)
        {
            notebookAnimator.SetBool("orderReady", true);
            boolNotebook = false;
            
        }
        else
        {
            boolNotebook = !assignedTray.GetComponent<orderChecked>().clientEntered;
        }
        
        
        if (boolNotebook == false && isBossBattle==false)
        {
            
            notebookAnimator.SetBool("orderReady", false);
            
            clientOrder = assignedTray.GetComponent<orderChecked>().clientOrder1;
            for (int i = 0; i < orderSprite.Length; i++)
            {
                orderSprite[i].sprite = GetOrderSprite(clientOrder[i]);
            }
        }
        else if(isBossBattle == true && boolNotebook == false)
        {
            notebookAnimator.SetBool("orderReady", false);
            for (int i = 0; i < orderSprite.Length; i++)
            {

                orderSprite[i].sprite = GetOrderSprite(GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitList[i]);
            }
            
        }

        if (boolNotebook == true)
        {
            notebookAnimator.SetBool("orderReady", true);
        }
        
        
    }

    IEnumerator disappearNotebook()
    {
        yield return new WaitForSeconds(4f);
        
    }




    public Sprite GetOrderSprite(string option)
    {
        switch (option)
        {
            default:
            case "Lemon_Fruit": return fruitImageReference.Instance.lemonSprite;
            case "Lime_Fruit": return fruitImageReference.Instance.limeSprite;
            case "Strawberry_Fruit": return fruitImageReference.Instance.strawberrySprite;
            case "Pitahaya_Fruit": return fruitImageReference.Instance.pitahayaSprite;
            
        }
    }



}
