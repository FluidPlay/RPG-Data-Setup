using NaughtyAttributes;
using UnityEngine;

public class IntScriptable: ScriptableObject
{
    [ShowNativeProperty]public int Value { get; set; }
}
