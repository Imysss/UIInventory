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

    private void RefreshUI()
    {
        if (_init == false)
            return;

        GetObject((int)GameObjects.InventoryScrollObject).DestroyChilds();
        
        //데이터 받아와서 인벤토리 추가하기
    }

    private void OnClickExitButton()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
