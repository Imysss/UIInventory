using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
    [TextArea] 
    public string description;
}
