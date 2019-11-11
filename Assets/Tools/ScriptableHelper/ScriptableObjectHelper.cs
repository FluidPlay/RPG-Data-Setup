using UnityEngine;
using UnityEditor;
using System;
using Object = UnityEngine.Object;

public class ScriptableObjectHelper : Editor {
	//path, isValidateFunction, Priority
	[MenuItem("Assets/Create/Scriptable Object Asset", false, 10000)]
	public static void CreateScriptableObjectAsset (){
		ScriptableObject asset = ScriptableObject.CreateInstance (Selection.activeObject.name);
		//Debug.Log(formatPath(Selection.activeObject));
		AssetDatabase.CreateAsset(asset, formatPath(Selection.activeObject)); // (asset, String.Format ("Assets/{0}.asset", Selection.activeObject.name));
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

	private static string formatPath(Object targetObject)
	{
		var path = AssetDatabase.GetAssetPath(targetObject);
		int lastPoint = path.LastIndexOf('.');
		path = (lastPoint > -1) ? path.Substring(0, lastPoint) : path;
		return path + ".asset";
	}

	[MenuItem("Assets/Create/Scriptable Object Asset", true, 10000)]
	public static bool CreateScriptableObjectAssetCheck (){
		if (Selection.activeObject.GetType () != typeof(MonoScript))
			return false;
		MonoScript script = (MonoScript)Selection.activeObject;
		var scriptClass = script.GetClass ();
		if (scriptClass == null)
			return false;
		return true;
		//return typeof(Manager).IsAssignableFrom (scriptClass.BaseType); //optional validate type check
	}
}