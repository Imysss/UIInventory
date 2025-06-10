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

    public bool RemoveItem(ItemData itemData, int amount = 1)
    {
        InventoryItem existing = items.Find(i => i.itemData == itemData);

        if (existing != null)
        {
            existing.quantity -= amount;
            if (existing.quantity <= 0)
            {
                items.Remove(existing);
                return true;
            }
        }

        return false;
    }

    public void EquipItem(ItemData itemData)
    {
        //같은 타입의 아이템이 이미 장착되어 있다면 해제
        foreach (var item in  items)
        {
            if (item.isEquipped && item.itemData.itemType == itemData.itemType)
            {
                item.isEquipped = false;
                break;
            }
        }
        
        InventoryItem targetItem = items.Find(i => i.itemData == itemData);
        if (targetItem != null && targetItem.quantity > 0)
        {
            targetItem.isEquipped = true;   
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
