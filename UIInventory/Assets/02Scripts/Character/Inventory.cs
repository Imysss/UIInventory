using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int quantity;
    public bool isEquipped;
}

[Serializable]
public class Inventory
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(ItemData itemData, int amount = 1)
    { 
        InventoryItem existing = items.Find(i => i.itemData == itemData);
        
        if (existing != null)
        {
            existing.quantity += amount;
        }
        else
        {
            items.Add(new InventoryItem()
            {
                itemData = itemData,
                quantity = amount,
                isEquipped = false
            });
        }
    }

    public void RemoveItem(ItemData itemData, int amount = 1)
    {
        InventoryItem existing = items.Find(i => i.itemData == itemData);

        if (existing != null)
        {
            existing.quantity -= amount;
            if (existing.quantity <= 0)
            {
                items.Remove(existing);
            }
        }
    }

    public void EquipItem(ItemData itemData)
    {
        InventoryItem item = items.Find(i => i.itemData == itemData);
        if (item != null && !item.isEquipped && item.quantity > 0)
        {
            item.isEquipped = true;   
        }
    }

    public void UnequipItem(ItemData itemData)
    {
        InventoryItem item = items.Find(i => i.itemData == itemData);
        if (item != null && item.isEquipped)
        {
            item.isEquipped = false;   
        }
    }
}
