using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        Debug.Log("@>> LobbyScene Init");
        base.Init();

        SceneType = Define.Scene.LobbyScene;

        Managers.UI.ShowSceneUI<UILobbyScene>();
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

    public override void Clear()
    {
        
    }
}
