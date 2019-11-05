using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour, IWeapon
{
    public float CurrentDamageMult = 1f;
    public float Damage;
    public float Reload;

    [DisplayScriptableObjectProperty]
    public AbstractWeaponData DefaultData;

    public void SetDamageMult(float mult)
    {
        CurrentDamageMult = mult;
    }
    
    private void Start() {
        Damage = DefaultData.Damage;
        Reload = DefaultData.Reload;
    }
}