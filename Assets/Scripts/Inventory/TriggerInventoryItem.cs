using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
public class TriggerInventoryItem : MonoBehaviour
{
     [Tooltip("The player's panel that will activate when near the chest.")]
    public GameObject itemCanvas;
    [Tooltip("The text component that will display 'E' when near the chest.")]
    public TextMeshProUGUI textComponent;
    
    [Tooltip("The inventory item to give to the player")]
    public InventoryItem itemToGive;
    
    public GameObject inventoryButton;

    public InventoryManager inventoryManager;

    Animator animator;

    private void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        if(itemCanvas == null) return;
        itemCanvas.SetActive(false);
        textComponent.text = "";
        
        
                
    }
    void Update()
    {
        
        if (textComponent == null) return;
        if (textComponent.text == "E")
        
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //ToDo protect against duplicate
                animator.SetBool("isOpen", true);
                if(itemToGive == null) return;
                if(itemToGive.isLootable)
                {
                    itemToGive.isLootable = false;
                    inventoryManager.AddItem(itemToGive);
                    inventoryButton.GetComponent<InventorySlotButtonUpdater>().UpdateInventorySlotButtonNames();
                    
                }
                

                Debug.Log(itemToGive);
                
                // maybe add "isLootableBool to the item object instead?"
                
            }
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !this.gameObject.CompareTag("Chest"))
        {
            inventoryManager = other.GetComponent<InventoryManager>();
            inventoryManager.AddItem(itemToGive);
            Destroy(gameObject);
            inventoryButton.GetComponent<InventorySlotButtonUpdater>().UpdateInventorySlotButtonNames();

        }
        
        if(this.gameObject.CompareTag("Chest"))
        {
            itemCanvas.SetActive(true);
            textComponent.text = "E";

        }
         
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Chest"))
        
            {
                // Deactivate player panel and clear text
                itemCanvas.SetActive(false);
                textComponent.text = "";
            }
        }
       
    }

    void InteractWithChest(Collider other)
    {
        other.GetComponent<InventoryManager>().AddItem(itemToGive);
        inventoryButton.GetComponent<InventorySlotButtonUpdater>().UpdateInventorySlotButtonNames();
                     
    }
}

