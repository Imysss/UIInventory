using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    #region Contents
    
    private GameManager _game = new GameManager();
    
    public static GameManager Game { get { return Instance?._game; } }
    
    #endregion

    #region Core

    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private UIManager _ui = new UIManager();
    
    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static SceneManagerEx Scene { get { return Instance?._scene; } }
    public static UIManager UI { get { return Instance?._ui; } }
    
    #endregion

    public static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject("@Managers");
            go.AddComponent<Managers>();
        }
    }

    public static void Clear()
    {
        Scene.Clear();
        UI.Clear();
        Resource.Clear();
    }
}
