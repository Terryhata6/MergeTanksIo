using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPerk : BasePerkSystem
{
   private int _armor = 1;

   public int Armor(int currentArmor)
   {
       int newArmor = currentArmor + _armor;
       return newArmor;
   }
}
