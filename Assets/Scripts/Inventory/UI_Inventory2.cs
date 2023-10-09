using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory2 : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlots;
    public Transform slotTemplate;
    public float cellsize;


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
                //use items 
                
                if (GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().isOnBlender)
                {
                    if(fruitAmount == 0)
                {
                    fruitList.Add(f.GetString());
                    
                }

                if (fruitAmount == 1)
                {
                    fruitList.Add(f.GetString());
                }

                if ( fruitAmount == 2)
                {
                    fruitList.Add(f.GetString());
                }

                    if (GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitsOnBlender < 3)
                    {
                        GameObject.FindWithTag("Blender").GetComponent<Blender_Inventory>().fruitsOnBlender++;
                        inventory.removeFruits(f);
                        fruitAmount++;
                    }   
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
