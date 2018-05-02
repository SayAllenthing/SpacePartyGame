using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public bool EditMode = true;

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

            EditMode = !EditMode;
        }
    }

    private void OnSceneGUI()
    {
        if (!EditMode)
            return;

        RoomManager component = (RoomManager)target;

        ModularContact[] contacts = component.GetComponentsInChildren<ModularContact>();

        foreach(ModularContact contact in contacts)
        {
            if(contact.Contact == null)
            {
                Handles.color = Color.red;
                if (Handles.Button(contact.transform.position, Quaternion.LookRotation(-contact.transform.forward), 1.25f, 2, Handles.ArrowHandleCap))
                {
                    contact.GenerateFloor();
                }

                Handles.color = Color.blue;
                if (Handles.Button(contact.transform.position, Quaternion.LookRotation(contact.transform.up), 1.25f, 2, Handles.ArrowHandleCap))
                {
                    string[] paths = AssetDatabase.FindAssets("t:WallObjectDataBase");
                    WallObjectDatabase database = (WallObjectDatabase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(paths[0]), typeof(WallObjectDatabase));

                    contact.GenerateWall(database);
                }
            }
        }
    }
}
