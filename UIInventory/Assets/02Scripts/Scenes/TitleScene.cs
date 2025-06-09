using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        Debug.Log("@>> TitleScene Init");
        base.Init();
        SceneType = Define.Scene.TitleScene;
    }

    public override void Clear()
    {
        
    }
}
