using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : UIBase
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        Managers.UI.SetCanvas(gameObject, false);
        return true;
    }
}
