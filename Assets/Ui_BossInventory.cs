using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

// This code sets de UI Inventory for the player. Based on the fruit recollected, it will update the players inventory
// it is also interactible so when  you click a fruit when youre on the blender, it will remove fruits from the player and add them
//in the blender to make a smoothie

public class Ui_BossInventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlots;
    public Transform slotTemplate;
    public float cellsize;
    public float VFXTime;
    public UnityEvent powerUpFruits;


    private void Start()
    {
        
    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.onFruitListChanged += Inventory_onFruitListChanged;

        RefreshInventoryItems();


    }

    private void Inventory_onFruitListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }


    IEnumerator loadJuice(List<string> fruitList)
    {
        Script_AudioManager.instance.PlayPlayerSFX("blenderMix");
        
        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().blenderAnimator.SetBool("openBlender", false);
        yield return new WaitForSeconds(0.6f);
        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().blenderVFX.Play();
        yield return new WaitForSeconds(VFXTime);
        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().blenderAnimator.SetBool("openBlender", true);
        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().SetJuice(fruitList);
    }


    private void RefreshInventoryItems()
    {
        

        itemSlots = transform.Find("itemsSlot");
        slotTemplate = itemSlots.Find("BaseSlot");
        int x = 0;
        int y = 0;
        foreach (Transform child in itemSlots)
        {
            if (child == slotTemplate) continue;
            Destroy(child.gameObject);
        }

        
        bool isOnBlender = GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().isOnBlender;
        int fruitAmount = GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitsOnBlender;
        List<string> fruitList = GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitList;


        foreach (Fruits f in inventory.getFruitsList())
        {
            RectTransform itemSlotRectTransform = Instantiate(slotTemplate, itemSlots).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                Script_AudioManager.instance.PlaySFX("pickFruit");
                //use items 

                
                    
                    if (fruitList[0] == "")
                {

                        fruitList[0] = f.GetString();


                    }

                if (fruitAmount == 1)
                {
                        fruitList[1] = f.GetString();

                    }

                if ( fruitAmount == 2)
                {
                        fruitList[2] = f.GetString();
                    powerUpFruits.Invoke();
                        //GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().SetJuice(fruitList);



                    }

                    if (GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitsOnBlender < 3)
                    {
                        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitsOnBlender++;
                        inventory.removeFruits(f);
                        fruitAmount++;

                    }   
                

            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * cellsize, y * cellsize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = f.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
            if (f.amount > 1)
            {
                uiText.SetText(f.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            x++;

        }
    }



}
