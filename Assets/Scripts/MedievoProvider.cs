using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Syrinj;

public class MedievoProvider : MonoBehaviour
{
    [Provides, FindResourceOfType(typeof(GameData))]
    [DisplayScriptableObjectProperty]
    public GameData _gameData; // TODO: Make Private

    public void Start()
    {
        //_gameData = Resources.LoadAll<ScriptableObject>("").FirstOrDefault();
        //Resources.Load("GameData.asset", typeof(ScriptableObject)) as ScriptableObject;
    }
}
