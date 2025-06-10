using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfoPopup : UIPopup
{
    enum Buttons
    {
        EquipButton,
        UnequipButton,
        UseButton,
        ExitButton
    }

    enum Images
    {
        ItemIconImage
    }

    enum Texts
    {
        ItemNameText,
        ItemTypeText,
        ItemQuantityText,
        ItemDescriptionText
    }
    
    [SerializeField] private InventoryItem _inventoryItemData;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        BindText(typeof(Texts));
        
        GetButton((int)Buttons.EquipButton).gameObject.BindEvent(OnClickEquipButton);
        GetButton((int)Buttons.UnequipButton).gameObject.BindEvent(OnClickUnequipButton);
        GetButton((int)Buttons.UseButton).gameObject.BindEvent(OnClickUseButton);
        GetButton((int)Buttons.ExitButton).gameObject.BindEvent(OnClickExitButton);

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
        {
            return;
        }
        
        GetImage((int)Images.ItemIconImage).sprite = _inventoryItemData.itemData.icon;
        GetText((int)Texts.ItemNameText).text = $"이름: {_inventoryItemData.itemData.itemName}";
        GetText((int)Texts.ItemTypeText).text = "타입: " +
            (_inventoryItemData.itemData.itemType == Define.ItemType.Consumable ? "소모품" : "장비");
        GetText((int)Texts.ItemQuantityText).text = $"수량: {_inventoryItemData.quantity}";
        GetText((int)Texts.ItemDescriptionText).text = _inventoryItemData.itemData.description;
        
        //Button
        GetButton((int)Buttons.EquipButton).gameObject.SetActive(!_inventoryItemData.isEquipped &&
                                                                 _inventoryItemData.itemData.itemType ==
                                                                 Define.ItemType.Equipable);
        GetButton((int)Buttons.UnequipButton).gameObject.SetActive(_inventoryItemData.isEquipped &&
                                                                   _inventoryItemData.itemData.itemType ==
                                                                   Define.ItemType.Equipable);
        GetButton((int)Buttons.UseButton).gameObject.SetActive(_inventoryItemData.itemData.itemType ==
                                                               Define.ItemType.Consumable);
        
    }

    private void OnClickEquipButton()
    {
        Managers.Game.Character.inventory.EquipItem(_inventoryItemData.itemData);
        (Managers.UI.SceneUI as UILobbyScene)?.UIInventoryPopup.SetInfo();
        RefreshUI();
    }

    private void OnClickUnequipButton()
    {
        Managers.Game.Character.inventory.UnequipItem(_inventoryItemData.itemData);
        (Managers.UI.SceneUI as UILobbyScene)?.UIInventoryPopup.SetInfo();
        RefreshUI();
    }

    private void OnClickUseButton()
    {
        Managers.Game.Character.inventory.RemoveItem(_inventoryItemData.itemData);
        (Managers.UI.SceneUI as UILobbyScene)?.UIInventoryPopup.SetInfo();
        RefreshUI();
    }
    
    private void OnClickExitButton()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
