using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlots;
    private Transform slotTemplate;
    public float cellsize;


    private void Start()
    {
        itemSlots = transform.Find("itemsSlot");
        slotTemplate = itemSlots.Find("BaseSlot");
    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }


    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        
        foreach ( Fruits f in inventory.getFruitsList())
        {
            RectTransform itemSlotRectTransform = Instantiate(slotTemplate, itemSlots).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * cellsize, y * cellsize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = f.GetSprite();
            x++;

        }
    }



}
