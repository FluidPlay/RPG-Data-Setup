using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, IArmor
{
    [DisplayScriptableObjectProperty]
    public IntVariable currentHealth;
    public float currentDamageMult = 1f;
    // Usamos um Abstract SO aqui para podermos tratar vários tipos de implementação diferentes
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
