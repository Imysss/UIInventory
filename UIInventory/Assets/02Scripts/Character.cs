using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
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
}
