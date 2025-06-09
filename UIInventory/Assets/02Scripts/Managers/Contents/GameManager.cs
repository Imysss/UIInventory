using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Character Character { get; private set; }
    public int Gold { get; private set; }
    
    public void Init()
    {
        Character = GameObject.FindObjectOfType<Character>();
        Gold = 777;
    }
    
}
