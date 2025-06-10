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
    
    private UIInventoryPopup _uiInventoryPopup;
    public UIInventoryPopup UIInventoryPopup { get { return _uiInventoryPopup; } }
    private UIStatusPopup _uiStatusPopup;
    public UIStatusPopup UIStatusPopup { get { return _uiStatusPopup; } }

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

        _uiInventoryPopup = Managers.UI.ShowPopupUI<UIInventoryPopup>();
        _uiStatusPopup = Managers.UI.ShowPopupUI<UIStatusPopup>();
        _uiInventoryPopup.gameObject.SetActive(false);
        _uiStatusPopup.gameObject.SetActive(false);
        
        RefreshUI();

        return true;
    }

    private void RefreshUI()
    {
        if (_init == false)
            return;
        
        GetText((int)Texts.NameText).text = data.characterName;
        GetText((int)Texts.LevelText).text = $"Lv. {data.level}";
        GetText((int)Texts.DescriptionText).text = data.description;
        GetText((int)Texts.GoldText).text = Managers.Game.Gold.ToString();
        GetText((int)Texts.ExpText).text = $"{data.exp} / {Managers.Game.Character.GetRequiredExp(data.level)}";
        GetObject((int)GameObjects.ExpSlider).GetComponent<Slider>().value =
            (float)data.exp / Managers.Game.Character.GetRequiredExp(data.level);
        GetImage((int)Images.PlayerImage).sprite = data.image;
    }

    private void OnClickStatusButton()
    {
        _uiStatusPopup.gameObject.SetActive(true);
    }

    private void OnClickInventoryButton()
    {
        _uiInventoryPopup.gameObject.SetActive(true);
    }
}
