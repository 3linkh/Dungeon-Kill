using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class InventoryManager : MonoBehaviour
{
    [Tooltip("The maximum number of items that can be held in the inventory.")]
    public int maxInventorySize = 20;

    [Tooltip("The current number of items in the inventory.")]
    [SerializeField]
    public int currentInventorySize = 0;

    [Tooltip("The list of items currently in the inventory.")]
    [SerializeField]
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    // Add an item to the inventory.
    public void AddItem(InventoryItem item)
    {
        if (currentInventorySize < maxInventorySize)
        {
            inventoryItems.Add(item);
            currentInventorySize++;
        }
        else
        {
            Debug.Log("Inventory is full.");
        }
    }

    // Remove an item from the inventory.
    public void RemoveItem(InventoryItem item)
    {
        if (inventoryItems.Remove(item))
        {
            currentInventorySize--;
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }
}