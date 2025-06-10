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

    enum Buttons
    {
        UIItemSlotButton
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
        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        
        GetButton((int)Buttons.UIItemSlotButton).gameObject.BindEvent(OnClickItemSlot);
        
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
        GetImage((int)Images.ItemImage).sprite = _inventoryItemData.itemData.icon;
        GetObject((int)GameObjects.EquipObject).gameObject.SetActive(_inventoryItemData.isEquipped);
    }

    private void OnClickItemSlot()
    {
        //아이템 이름, 수량, 정보, 장착/장착해제 버튼이 적혀져 있는 아이템 창 띄우기
        UIItemInfoPopup itemInfoPopup = Managers.UI.ShowPopupUI<UIItemInfoPopup>();
        itemInfoPopup.SetInfo(_inventoryItemData);
    }
}
