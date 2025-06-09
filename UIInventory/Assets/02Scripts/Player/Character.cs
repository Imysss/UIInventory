using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   //Tmp: Inventory에 들어갈 item 내용물들
   public ItemData[] ItemDatas;
   
   public CharacterData characterData;
   public Inventory inventory = new Inventory();

   //Info
   [SerializeField] private int level;
   [SerializeField] private int exp;
   
   //Stat
   [SerializeField] private int currentAtk;
   [SerializeField] private int currentDef;
   [SerializeField] private int currentHp;
   [SerializeField] private int currentCritical;

   private void Start()
   {
      level = characterData.level;
      exp = characterData.exp;
      
      currentAtk = characterData.atk;
      currentDef = characterData.def;
      currentHp = characterData.hp;
      currentCritical = characterData.critical;
   }

   public void AddExp(int amount)
   {
      exp += amount;
      TryLevelUp();
   }

   private void TryLevelUp()
   {
      while (exp >= GetRequiredExp(level))
      {
         exp -= GetRequiredExp(level);
         level++;
      }
   }

   public int GetRequiredExp(int level)
   {
      while (level < 1 || level >= Define.expTable.Length)
         return Define.expTable[Define.expTable.Length - 1];

      return Define.expTable[level];
   }
   
}
