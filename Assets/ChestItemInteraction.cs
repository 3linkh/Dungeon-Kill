using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemInteraction : MonoBehaviour
{
    [Tooltip("The inventory item to give to the player")]
    public InventoryItem itemToGive;
    
    public GameObject inventoryButton;

    private void Awake() 
    {
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TransferInventoryItem(other);
        }
    }

    public void TransferInventoryItem(Collider player)
    {
        player.GetComponent<InventoryManager>().AddItem(itemToGive);
        Destroy(gameObject);
        inventoryButton.GetComponent<InventorySlotButtonUpdater>().UpdateInventorySlotButtonNames();
    }
}
