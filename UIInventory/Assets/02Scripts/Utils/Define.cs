using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum UIEvent
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp, 
        Drag,
        BeginDrag,
        EndDrag,
    }

    public enum Scene
    {
        Unknown,
        TitleScene,
        LobbyScene,
        GameScene,
    }    
    
    public static int[] expTable = new int[]
    {
        0,    // 0레벨 (실제로 사용 안 함)
        100,  // 1 -> 2
        250,  // 2 -> 3
        450,  // 3 -> 4
        700,  // 4 -> 5
        1000, // 5 -> 6
        1400, // ...
        1850,
        2350,
        2900,
        3500
    };
}
