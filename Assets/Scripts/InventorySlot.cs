using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if(transform.childCount == 0) {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        } else {
           InventoryItem itemInSlot = this.GetComponentInChildren<InventoryItem>();
           InventoryItem pickedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
           if(itemInSlot.item  == pickedItem.item) {
                Debug.Log("It's a match");
           } else {
            Debug.Log("Not a match");
           }
            
        }
    }
}
