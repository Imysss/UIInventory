using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;
    public int level;
    public int exp;
    [TextArea]
    public string description;
    public Sprite image;

    [Header("Character Status")] 
    public int atk;
    public int def;
    public int hp;
    public int critical;
}
