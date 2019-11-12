using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Syrinj;

public class MedievoProvider : MonoBehaviour
{
    // TODO: Make Private
    [DisplayScriptableObjectProperty]
    [Provides, FindResourceOfType(typeof(GameData))]
    public GameData _gameData;

    public void Start()
    {
        //_gameData = Resources.LoadAll<ScriptableObject>("").FirstOrDefault();
        //Resources.Load("GameData.asset", typeof(ScriptableObject)) as ScriptableObject;
    }
}
