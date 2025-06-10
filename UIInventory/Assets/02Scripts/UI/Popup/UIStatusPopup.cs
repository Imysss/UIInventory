using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UIStatusPopup : UIPopup
{
    enum Buttons
    {
        ExitButton,
    }
    
    enum Texts
    {
        AtkText,
        DefText,
        HpText,
        CriticalText,
    }

    private CharacterData data;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        data = Managers.Game.Character.characterData;
        
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
        
        GetText((int)Texts.AtkText).text = data.atk.ToString();
        GetText((int)Texts.DefText).text = data.def.ToString();
        GetText((int)Texts.HpText).text = data.hp.ToString();
        GetText((int)Texts.CriticalText).text = data.critical.ToString();
    }

    private void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }
}
