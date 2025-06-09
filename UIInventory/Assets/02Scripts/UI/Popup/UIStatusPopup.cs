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

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.ExitButton).gameObject.BindEvent(OnClickExitButton);
        
        RefreshUI();
        
        return true;
    }

    private void RefreshUI()
    {
        
    }

    private void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }
}
