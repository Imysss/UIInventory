using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobbyScene : UIScene
{
    enum GameObjects
    {
        ExpSlider
    }

    enum Buttons
    {
        StatusButton,
        InventoryButton,
    }

    enum Texts
    {
        NameText,
        LevelText,
        ExpText,
        DescriptionText,
        GoldText,
    }

    enum Images
    {
        PlayerImage
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        GetButton((int)Buttons.StatusButton).gameObject.BindEvent(OnClickStatusButton);
        GetButton((int)Buttons.InventoryButton).gameObject.BindEvent(OnClickInventoryButton);
        
        RefreshUI();

        return true;
    }

    private void RefreshUI()
    {
        //GetText((int)Texts.GoldText).text = Managers.Game.Character.Gold.ToString();
        //GetText((int)Texts.ExpText).text =
    }

    private void OnClickStatusButton()
    {
        Debug.Log("StatusButton Click");
        Managers.UI.ShowPopupUI<UIStatusPopup>();
    }

    private void OnClickInventoryButton()
    {
        Debug.Log("InventoryButton Click");
        Managers.UI.ShowPopupUI<UIInventoryPopup>();
    }
}
