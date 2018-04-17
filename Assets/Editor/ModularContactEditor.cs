using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ModularContact))]
public class ModularContactEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ModularContact component = (ModularContact)target;

        if (GUILayout.Button("Generate Wall"))
        {
            string[] paths = AssetDatabase.FindAssets("t:WallObjectDataBase");
            WallObjectDatabase database = (WallObjectDatabase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(paths[0]), typeof(WallObjectDatabase));

            component.GenerateWall(database);
        }

        if (GUILayout.Button("Generate Floor"))
        {
            component.GenerateFloor();
        }
    }
}
