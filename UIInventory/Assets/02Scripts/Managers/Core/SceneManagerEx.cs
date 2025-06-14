using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type, Transform parents = null)
    {
        switch (CurrentScene.SceneType)
        {
            case Define.Scene.TitleScene:
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.Scene.LobbyScene:
                Time.timeScale = 1;
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.Scene.GameScene:
                Time.timeScale = 1;
                SceneManager.LoadScene(GetSceneName(type));
                break;
        }
    }

    string GetSceneName(Define.Scene type)
    {
        return System.Enum.GetName(typeof(Define.Scene), type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
