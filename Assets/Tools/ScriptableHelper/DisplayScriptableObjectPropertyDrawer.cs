 using UnityEditor;
 using UnityEngine;

 [CustomPropertyDrawer(typeof(DisplayScriptableObjectPropertyAttribute))]
 public class DisplayScriptableObjectPropertyDrawer : PropertyDrawer
 {
     bool showProperty = false;
     float DrawerHeight = 0;

     string button = "-";

     private GUIStyle _customButton;
     private GUIStyle customButton
     {
         get
         {
             if (_customButton == null) {
                 _customButton = new GUIStyle("button");
                 _customButton.fontSize = 6;
                 _customButton.border = new RectOffset(0,0,0,0);
                 _customButton.padding = new RectOffset(0, 0, 0, 0);
             }
             return _customButton;
         }
     }

     // Draw the property inside the given rect
     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
     {
         var e = Editor.CreateEditor(property.objectReferenceValue);
         var indent = EditorGUI.indentLevel;
         Rect drawPos = new Rect(position.x - 10, position.y + 1, 11, 11);
         if (GUI.Button(drawPos, button, customButton))
             if (showProperty) {
                 showProperty = false;
                 button = ">";
             } else {
                 showProperty = true;
                 button = "v";
             }

         DrawerHeight = 0;
         position.height = 16;
         EditorGUI.PropertyField(position, property);
         position.y += 20;
         if (!showProperty) 
             return;
         if (e != null) {
             position.x += 20;
             position.width -= 40;
             var so = e.serializedObject;
             so.Update();
             var prop = so.GetIterator();
             //Debug.Log(" prop.hasVisibleChildren " + prop.hasVisibleChildren);
             prop.NextVisible(true);
             int depthChilden = 0;
             bool showChilden = false;
             while (prop.NextVisible(true)) {
                 if (prop.depth == 0) {
                     showChilden = false;
                     depthChilden = 0;
                 }
                 if (showChilden && prop.depth > depthChilden)
                     continue;

                 position.height = 16;
                 EditorGUI.indentLevel = indent + prop.depth;
                 if (EditorGUI.PropertyField(position, prop))
                     showChilden = false;
                 else {
                     showChilden = true;
                     depthChilden = prop.depth;
                 }

                 position.y += 20;
                 SetDrawerHeight(20);
             }

             if (GUI.changed)
                 so.ApplyModifiedProperties();
         }
     }

     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
     {
         float height = base.GetPropertyHeight(property, label);
         height += DrawerHeight;
         return height;
     }

     void SetDrawerHeight(float height)
     {
         this.DrawerHeight += height;
     }
}
