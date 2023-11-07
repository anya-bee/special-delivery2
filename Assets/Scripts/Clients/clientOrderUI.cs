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

    public Animator notebookAnimator;
    // Start is called before the first frame update
    void Start()
    {
        clientOrder.Add("");
        clientOrder.Add("");
        clientOrder.Add("");
        notebookAnimator.SetBool("orderReady", true);
    }

    // Update is called once per frame
    void Update()
    {
        boolNotebook = !assignedTray.GetComponent<orderChecked>().clientEntered;
        if (boolNotebook == false )
        {
            notebookAnimator.SetBool("orderReady", false);
            clientOrder = assignedTray.GetComponent<orderChecked>().clientOrder1;
            for (int i = 0; i < orderSprite.Length; i++)
            {
                orderSprite[i].sprite = GetOrderSprite(clientOrder[i]);
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
