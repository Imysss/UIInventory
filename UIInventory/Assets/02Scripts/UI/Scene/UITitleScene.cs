using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITitleScene : UIScene
{
    enum GameObjects
    {
        LoadingSlider,
    }

    enum Buttons
    {
        StartButton,
        ExitButton,
    }

    private bool _isPreload = false;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("Preload", (key, count, totalCount) =>
        {
            GetObject((int)GameObjects.LoadingSlider).GetComponent<Slider>().value = (float)count / totalCount;
            if (count == totalCount)
            {
                _isPreload = true;
                GetButton((int)Buttons.StartButton).gameObject.SetActive(true);
            }
        });
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));

        GetObject((int)GameObjects.LoadingSlider).GetComponent<Slider>().value = 0;
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(() =>
        {
            if (_isPreload)
                Managers.Scene.LoadScene(Define.Scene.LobbyScene, transform);
        });
        
        GetButton((int)Buttons.ExitButton).gameObject.BindEvent(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
        });
        
        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);

        return true;
    }
}
