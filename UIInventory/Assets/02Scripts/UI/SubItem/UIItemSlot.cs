using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemSlot : UIBase
{
    enum GameObjects
    {
        EquipObject
    }

    enum Images
    {
        ItemImage
    }

    [SerializeField] private InventoryItem _inventoryItemData;
    
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindImage(typeof(Images));
        
        return true;
    }

    public void SetInfo(InventoryItem data)
    {
        transform.localScale = Vector3.one;
        _inventoryItemData = data;
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (_init == false)
            return;
        
        GetImage((int)Images.ItemImage).sprite = _inventoryItemData.itemData.icon;
        GetObject((int)GameObjects.EquipObject).gameObject.SetActive(_inventoryItemData.isEquipped);
    }
}
