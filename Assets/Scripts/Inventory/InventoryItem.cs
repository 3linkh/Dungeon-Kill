using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    [Tooltip("The name of the item")]
    public string itemName = "New Item";
    
    [Tooltip("The icon of the item")]
    public Sprite itemIcon = null;
    
    [Tooltip("The description of the item")]
    public string itemDescription = "Item Description";
    
    [Tooltip("The maximum stack size of the item")]
    public int maxStackSize = 1;
    
    [Tooltip("Is the item stackable?")]
    public bool isStackable = true;
    
    [Tooltip("Is the item a quest item?")]
    public bool isQuestItem = false;

    [Tooltip("Is the item lootable?")]
    public bool isLootable = true;

    public bool isEquipable = false;
    public Weapon weapon;

}