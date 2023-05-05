using UnityEngine;
using TMPro;

public class ChestInteraction : MonoBehaviour
{
    [Tooltip("The player's panel that will activate when near the chest.")]
    public GameObject chestCanvas;
    [Tooltip("The text component that will display 'E' when near the chest.")]
    public TextMeshProUGUI textComponent;
    [Tooltip("The distance at which the player can interact with the chest.")]
    public float interactionDistance = 2f;

    
    [Tooltip("The inventory item to give to the player")]
    public InventoryItem itemToGive;
    
    public GameObject inventoryButton;

    private bool isNearChest = false;

    private void Awake() 
    {
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        chestCanvas.SetActive(false);
        textComponent.text = ""; 
    }

    private void Update()
    {
        // Check if player is near the chest
        if (isNearChest)
        {
            // Activate player panel and display 'E'
            chestCanvas.SetActive(true);
            textComponent.text = "E";

            // Check if player is pressing the interact button
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<InventoryManager>().AddItem(itemToGive);
                inventoryButton.GetComponent<InventorySlotButtonUpdater>().UpdateInventorySlotButtonNames();
                                
            }
        }
        else
        {
            // Deactivate player panel and clear text
            chestCanvas.SetActive(false);
            textComponent.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if other collider has the 'Player' tag
        if (other.CompareTag("Chest"))
        {
            // Check if player is within interaction distance
            
            {
                isNearChest = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if other collider has the 'Player' tag
        if (other.CompareTag("Chest"))
        {
            isNearChest = false;
        }
    }
    
}