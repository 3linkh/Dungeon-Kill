using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlotButtonUpdater : MonoBehaviour
{
    [Tooltip("The parent object of the inventory slot buttons.")]
    [SerializeField] private GameObject inventorySlotButtonParent;

    [Tooltip("The inventory manager that holds the inventory items.")]
    [SerializeField] InventoryManager inventoryManager;

    private void Start()
    {
        UpdateInventorySlotButtonNames();
    }

    public void UpdateInventorySlotButtonNames()
    {
        // Get all inventory slot buttons
        Button[] inventorySlotButtons = inventorySlotButtonParent.GetComponentsInChildren<Button>();

        // Loop through each inventory slot button
        for (int i = 0; i < inventorySlotButtons.Length; i++)
        {
            // Check if the inventory item exists at the current index
            //if (i < inventoryManager.currentInventorySize)
            //{
                // Get the inventory item stored in the inventory manager
                InventoryItem inventoryItem = inventoryManager.inventoryItems[i];

                // Update the text mesh pro text of the inventory slot button with the inventory item name
                inventorySlotButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = inventoryItem.itemName;
                inventorySlotButtons[i].GetComponentInChildren<Image>().sprite = inventoryItem.itemIcon;
           // }
            // else
            // {
            //     // If the inventory item does not exist at the current index, clear the text mesh pro text of the inventory slot button
            //     inventorySlotButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            // }
        }
    }
}