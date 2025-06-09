using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int level;
    [SerializeField] private int exp;
    [SerializeField] private string description;
    [SerializeField] private int gold;
    
    public int Gold { get => gold; }
    
}
