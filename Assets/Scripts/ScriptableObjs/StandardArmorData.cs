using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StandardArmorData : AbstractArmorData
{
    //[baseClass] public int MaxHealth;
    
    /// <summary> Multiplier to all damage taken by this armor, usually a reducer (<1) </summary>
    public float DamageMultiplier;
}
