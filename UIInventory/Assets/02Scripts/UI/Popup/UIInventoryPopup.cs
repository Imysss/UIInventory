using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPopup : UIPopup
{
    enum GameObjects
    {
        InventoryScrollObject,
    }
    enum Buttons
    {
        ExitButton,
    }
    enum Texts
    {
        InventoryCountText,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        
        GetButton((int)Buttons.ExitButton).gameObject.BindEvent(OnClickExitButton);

        RefreshUI();
        
        return true;
    }

    public void SetInfo()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (_init == false)
            return;
        
        GetObject((int)GameObjects.InventoryScrollObject).DestroyChilds();

        int count = 0;
        //데이터 받아와서 인벤토리 추가하기
        foreach (InventoryItem data in Managers.Game.Character.inventory.items)
        {
            UIItemSlot item =
                Managers.UI.MakeSubItem<UIItemSlot>(GetObject((int)GameObjects.InventoryScrollObject).transform);
            item.SetInfo(data);
            count++;
        }

        GetText((int)Texts.InventoryCountText).text = $"{count} / 100";
    }

    private void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }
}
