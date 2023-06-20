using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;

    public InventorySlot[] inventorySlots;
    public GameObject invetoryItemPrefab;

    private void Awake() {
        instance = this;
    }


    // Find an empty Slot
    public bool AddItem(Item item) {

        for(int i= 0 ; i < inventorySlots.Length ; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.item.isStackable == true) {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                SpawnNewItem(item, slot);
                return true;
            } 
        }


        for(int i= 0 ; i < inventorySlots.Length ; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null) {
                SpawnNewItem(item, slot);
                return true;
            } 
        }

    return false;
    }

    public void SpawnNewItem (Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(invetoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item); 


    }
}
 