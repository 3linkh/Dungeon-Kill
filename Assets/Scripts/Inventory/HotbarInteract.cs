using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarInteract : MonoBehaviour

{
    [SerializeField] private GameObject hotBarButtonParent;

    [Tooltip("Maximum number of items that can be added to the hotbar.")]
    public int maxHotBarSize = 5;

    [Tooltip("Current number of items in the hotbar.")]
    public int currentHotBarSize = 0;
    
    [Tooltip("Array of items in the hotbar.")]
    public InventoryItem[] hotBarItems = new InventoryItem[5];

    public InventoryManager inventoryManager;

    public InventoryItem inventoryItem;

    private void Start()
    {
        Button[] hotBarButtons = hotBarButtonParent.GetComponentsInChildren<Button>();
        
        UpdateHotBarItemArray();
    }

    public void UseHotBarItem()
    {
        //if consumable, use it
        //if equippable, equip it
        
       if (hotBarItems == null) return;
          

       else if (inventoryItem.weapon.weaponIsUsable)
        {
           GetComponent<Fighter>().EquipWeapon(inventoryItem.weapon);
            
        } 
        else 
        {
            print("item is not useable so cant be equipped");
        }   
        UpdateHotBarItemArray();
    }
    
    void UpdateHotBarItemArray()
    {
        for (int i = 0; i < hotBarItems.Length; i++)
        {
            Button[] hotBarButtons = hotBarButtonParent.GetComponentsInChildren<Button>();

            hotBarButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = hotBarItems[i].itemName; 
            hotBarButtons[i].GetComponentInChildren<Image>().sprite = hotBarItems[i].itemIcon;
            


            //assign to a button
            //if assigned button is clicked - activate (use item (and destroy it), equip item if weapon)
            print (hotBarItems[i].name);
        }
    }
         

    // Add an item to the hotbar.
    public void AddItem(InventoryItem item)
    {
        if (currentHotBarSize < maxHotBarSize)
        {
            hotBarItems[currentHotBarSize] = item;
            currentHotBarSize++;
        }
        else
        {
            Debug.Log("Hotbar is full.");
        }
        UpdateHotBarItemArray();
    }

    // Remove an item from the hotbar.
    public void RemoveItem(InventoryItem item)
    {
        for (int i = 0; i < currentHotBarSize; i++)
        {
            if (hotBarItems[i] == item)
            {
                hotBarItems[i] = null;
                currentHotBarSize--;
                return;
            }
        }
        Debug.Log("Item not found on Hotbar.");
        UpdateHotBarItemArray();
    }
    public void TestItemAdd(InventoryItem item)
    {
        if(Input.GetKeyDown("T"))
        {
            AddItem(item);
        }
    }

    }
