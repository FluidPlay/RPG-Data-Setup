using System;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

/// Author: CrispyBeans
/// From: https://forum.unity.com/threads/missing-documentation-for-scriptable-singleton.292754/

namespace Utils {
 
 
    // Crispy->Thomas: We'll use this to create a manager to handle the Editor configuration of the new Camera Capture Kit Manager
    // so that we can better handle editor singleton classes that require persistence, like Native Android Log Manager ( adb ) and iOS log Manager.
    // TODO: (Thomas) when a Native Photo is grapped from Android Camera we need to be able to capture the log as well as inspecting the camera
    // properties. When the project is reloaded we dont want the parametres to be reloaded.
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;
        public static T instance  {
            get {
                if (_instance == null)
                    CreateAndLoad();
                return _instance;
            }
        }
        protected ScriptableSingleton() {
            if (_instance != null)
                Debug.LogError("ScriptableSingleton already exists. Did you query the singleton in a constructor?");
            else
                _instance = (this as T);
        }
        private static void CreateAndLoad() {
            string filePath = GetFilePath();
            if (!string.IsNullOrEmpty(filePath))
                InternalEditorUtility.LoadSerializedFileAndForget(filePath);
            if (_instance == null) {
                T t = ScriptableObject.CreateInstance<T>();
                t.hideFlags = HideFlags.HideAndDontSave;
            }
        }
        protected virtual void Save(bool saveAsText) {
            if (_instance == null) {
                Debug.Log("Cannot save ScriptableSingleton: no instance!");
                return;
            }
            string filePath = GetFilePath();
            if (!string.IsNullOrEmpty(filePath)) {
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);
                InternalEditorUtility.SaveToSerializedFileAndForget(new []
                    { _instance }, filePath, saveAsText
                );
            }
        }
        private static string GetFilePath()
        {
            var typeFromHandle = typeof(T);
            object[] customAttributes = typeFromHandle.GetCustomAttributes(true);
            object[] array = customAttributes;
            for (int i = 0; i < array.Length; i++) {
                object obj = array[i];
                if (obj is FilePathAttribute) {
                    FilePathAttribute filePathAttribute = obj as FilePathAttribute;
                    return filePathAttribute.filepath;
                }
            }
            return null;
        }
    }
 
 
    [AttributeUsage(AttributeTargets.Class)]
    public class FilePathAttribute : Attribute
    {
        public enum Location { PreferencesFolder, ProjectFolder }
        public string filepath { get; }
        public FilePathAttribute(string relativePath, Location location)
        {
            if (string.IsNullOrEmpty(relativePath)) {
                Debug.LogError("Invalid relative path! (its null or empty)");
                return;
            }
            if (relativePath[0] == '/') {
                relativePath = relativePath.Substring(1);
            }
            if (location == Location.PreferencesFolder)
                filepath = InternalEditorUtility.unityPreferencesFolder + "/" + relativePath;
            else
                filepath = relativePath;
        }
    }
 
}

//using System.Linq;
//using UnityEngine;
//
///// <summary>
///// Abstract class for making reload-proof singletons out of ScriptableObjects
///// Returns the asset created on the editor, or null if there is none
///// Based on https://www.youtube.com/watch?v=VBA1QCoEAX4
///// </summary>
///// <typeparam name="T">Singleton type</typeparam>
//
//public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject {
//    static T _instance = null;
//    public static T Instance
//    {
//        get
//        {
//            if (!_instance)
//                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
//            return _instance;
//        }
//    }
//}