using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractArmorData : ScriptableObject
{
    // TL;DR: "Não é qualquer scriptableobject, tem que ser de armadura"
    
    // Essa classe só existe para ser derivada e "filtrar" as classes desejadas nos campos públicos da Unity
    // não colocaremos código aqui. Isso será implementado na classe derivada, filtrado possivelmente
    // por uma interface (ex.: IArmor). Campos (fields) comuns podem ser acrescentados, devem ser comentados 
    // nas classes derivadas para não "ofuscá-los"
    
    public int MaxHealth;
}
