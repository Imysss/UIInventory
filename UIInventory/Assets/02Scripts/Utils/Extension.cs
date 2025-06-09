using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension 
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return Util.GetOrAddComponent<T>(go);
    }

    public static void BindEvent(this GameObject go, Action action = null, Action<BaseEventData> dragAction = null,
        Define.UIEvent type = Define.UIEvent.Click)
    {
        
        UIBase.BindEvent(go, action, dragAction, type);
    }

    public static void DestroyChilds(this GameObject go)
    {
        Transform[] children = new Transform[go.transform.childCount];
        for (int i = 0; i < go.transform.childCount; i++)
        {
            children[i] = go.transform.GetChild(i);
        }

        foreach (Transform child in children)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
    }
}
