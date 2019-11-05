using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, IArmor
{
    [DisplayScriptableObjectProperty]
    public IntScriptable currentHealth;
    public float currentDamageMult = 1f;
    [DisplayScriptableObjectProperty]
    public AbstractArmorData DefaultData;
    
    public int ApplyDamage(int damage)
    {
        currentHealth.Value -= Mathf.RoundToInt(damage * currentDamageMult);
        return currentHealth.Value;
    }

    private void Start() {
        currentHealth.Value = DefaultData.MaxHealth;
        var standardArmor = DefaultData as StandardArmorData;
        if (standardArmor)
            currentDamageMult = standardArmor.DamageMultiplier;
    }
}
