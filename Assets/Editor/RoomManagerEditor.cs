using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RoomManager component = (RoomManager)target;        

        if(GUILayout.Button("GenerateWalls"))
        {
            string[] paths = AssetDatabase.FindAssets("t:WallObjectDataBase");
            WallObjectDatabase database = (WallObjectDatabase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(paths[0]), typeof(WallObjectDatabase));

            component.GenerateWalls(database);
        }

        if(GUILayout.Button("Generate Floor"))
        {
            component.GenerateFloor();
        }

        if(GUILayout.Button("Toggle Edit Mode"))
        {
            ModularContact[] contacts = component.GetComponentsInChildren<ModularContact>(true);

            foreach(ModularContact c in contacts)
            {
                c.gameObject.SetActive(!c.gameObject.activeSelf);
            }
        }
    }
}
