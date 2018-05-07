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

        if(component.Floors.Count == 0)
        {
            if(GUILayout.Button("Generate Floor"))
            {
                component.GenerateFloor();
            }
        }

        if (GUILayout.Button("Toggle Edit Mode"))
        {
            ModularContact[] contacts = component.GetComponentsInChildren<ModularContact>(true);

            component.EditState.EditMode = !component.EditState.EditMode;

            foreach (ModularContact c in contacts)
            {
                c.gameObject.SetActive(component.EditState.EditMode);
            }            
        }

        if(GUILayout.Button("Generate Room Collider"))
        {
            component.GenerateCollider();
        }
    }

    private void OnSceneGUI()
    {
        RoomManager component = (RoomManager)target;

        if (!component.EditState.EditMode)
            return;

        List<FloorComponent> destroy = new List<FloorComponent>();

        List<FloorComponent> tempList = new List<FloorComponent>(component.Floors);
        
        foreach(FloorComponent floor in tempList)
        {
            foreach(ModularContact contact in floor.Contacts)
            {
                if(contact.Contact == null)
                {
                    if(component.EditState.EditFloors)
                    {
                        Handles.color = Color.cyan;
                        if (Handles.Button(contact.transform.position, Quaternion.LookRotation(-contact.transform.forward), 1.25f, 2, Handles.ArrowHandleCap))
                        {
                            contact.GenerateFloor();
                        }
                    }

                    if (component.EditState.EditWalls)
                    {
                        Handles.color = Color.yellow;
                        if (Handles.Button(contact.transform.position, Quaternion.LookRotation(contact.transform.up), 1.25f, 2, Handles.ArrowHandleCap))
                        {
                            string[] paths = AssetDatabase.FindAssets("t:WallObjectDataBase");
                            WallObjectDatabase database = (WallObjectDatabase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(paths[0]), typeof(WallObjectDatabase));

                            contact.GenerateWall(database);
                        }
                    }
                }
            }

            if(component.EditState.EditFloors)
            {
                Handles.color = Color.red;
                if (Handles.Button(floor.transform.position, Quaternion.LookRotation(Vector3.up), 0.75f, 1f, Handles.CircleHandleCap))
                {
                    destroy.Add(floor);
                }
            }
        }
        
        for(int i = destroy.Count - 1; i >= 0; i--)
        {
            component.Floors.Remove(destroy[i]);
            DestroyImmediate(destroy[i].gameObject);
        }        
    }
}
