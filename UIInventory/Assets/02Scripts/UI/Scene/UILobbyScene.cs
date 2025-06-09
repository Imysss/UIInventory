using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private CharacterData data;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        data = Managers.Game.Character.characterData;
        
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
        GetText((int)Texts.NameText).text = data.characterName;
        GetText((int)Texts.LevelText).text = $"Lv. {data.level}";
        GetText((int)Texts.DescriptionText).text = data.description;
        GetText((int)Texts.GoldText).text = Managers.Game.Gold.ToString();
        GetText((int)Texts.ExpText).text = $"{data.exp} / {Managers.Game.Character.GetRequiredExp(data.level)}";
        GetObject((int)GameObjects.ExpSlider).GetComponent<Slider>().value =
            (float)data.exp / Managers.Game.Character.GetRequiredExp(data.level);
    }

    private void OnClickStatusButton()
    {
        Managers.UI.ShowPopupUI<UIStatusPopup>();
    }

    private void OnClickInventoryButton()
    {
        Managers.UI.ShowPopupUI<UIInventoryPopup>();
    }
}
