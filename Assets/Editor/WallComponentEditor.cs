using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallComponent))]
public class WallComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WallComponent component = (WallComponent)target;
        
        component.Type = (WallObjectType)EditorGUILayout.EnumPopup("Type", component.Type);

        if(GUILayout.Button("Generate Wall"))
        {
            string[] paths = AssetDatabase.FindAssets("t:WallObjectDataBase");
            WallObjectDatabase database = (WallObjectDatabase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(paths[0]), typeof(WallObjectDatabase));

            component.GenerateWall(database, component.Type);            
        }
    }
}
