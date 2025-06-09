using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager 
{
    private int _order = 10;
    private int _toastOrder = 500;
    
    Stack<UIPopup> _popupStack = new Stack<UIPopup>();
    Stack<UIToast> _toastStack = new Stack<UIToast>();
    private UIScene _sceneUI = null;
    public UIScene SceneUI { get { return _sceneUI; } }

    public Action<int> OnTimeScaleChanged;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UIRoot");
            if (root == null)
                root = new GameObject { name = "@UIRoot" };
            return root;
        }
    }
    
    //Popup, Scene, Toast 등 UI 용도에 따라 Canvas Scale과 Order 조정
    public void SetCanvas(GameObject go, bool sort = true, int sortOrder = 0, bool isToast = false)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        if (canvas == null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
        }

        CanvasScaler cs = go.GetOrAddComponent<CanvasScaler>();
        if (cs != null)
        {
            cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cs.referenceResolution = new Vector2(1920, 1080);
        }

        go.GetOrAddComponent<GraphicRaycaster>();

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = sortOrder;
        }

        if (isToast)
        {
            _toastOrder++;
            canvas.sortingOrder = _toastOrder;
        }
    }

    public void RefreshTimeScale()
    {
        if(SceneManager.GetActiveScene().name != Define.Scene.GameScene.ToString())
        {
            Time.timeScale = 1;
            return;
        }

        if (_popupStack.Count > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        DOTween.timeScale = 1;
        OnTimeScaleChanged?.Invoke((int)Time.timeScale);
    }

    public void Clear()
    {
        CloseAllPopupUI();
        Time.timeScale = 1;
        _sceneUI = null;
    }

    #region Scene UI

    public T ShowSceneUI<T>(string name = null) where T : UIScene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate(name);
        go.transform.SetParent(Root.transform);

        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        return sceneUI;
    }

    #endregion

    #region SubItem UI

    public T MakeSubItem<T>(Transform parent = null, string name = null, bool pooling = true) where T : UIBase
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate(name, parent, pooling);
        go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }

    #endregion
    
    #region Popup UI

    public T ShowPopupUI<T>(string name = null) where T : UIPopup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        
        GameObject go = Managers.Resource.Instantiate(name);
        go.transform.SetParent(Root.transform);

        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        RefreshTimeScale();
        
        return popup;
    }
    
    public void ClosePopupUI(UIPopup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popupp Failed");
            return;
        }
        
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UIPopup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        _order--;
        RefreshTimeScale();
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
    #endregion

    #region Toast UI

    public UIToast ShowToast(string msg)
    {
        string name = typeof(UIToast).Name;
        
        GameObject go = Managers.Resource.Instantiate($"{name}", pooling: true);
        go.transform.SetParent(Root.transform);
        UIToast toast = Util.GetOrAddComponent<UIToast>(go);
        toast.SetInfo(msg);
        
        _toastStack.Push(toast);

        CoroutineManager.StartCoroutine(CoCloseToastUI());
        return toast;
    }

    private IEnumerator CoCloseToastUI()
    {
        yield return new WaitForSeconds(1f);
        CloseToastUI();
    }

    public void CloseToastUI()
    {
        if (_toastStack.Count == 0)
            return;
        
        UIToast toast = _toastStack.Pop();
        Managers.Resource.Destroy(toast.gameObject);
        _toastOrder--;
    }

    #endregion
}
