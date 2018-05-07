using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    const float TileSize = 3;
    const float Roomheight = 2;

    public GameObject WallPrefab;
    public GameObject FloorPrefab;

    public List<FloorComponent> Floors = new List<FloorComponent>();

    public RoomInfo Info;
    public RoomEditorState EditState;

    public void GenerateFloor()
    {
        if (Floors.Count > 0)
            return;

        GameObject go = Instantiate(FloorPrefab, transform);
        FloorComponent floor = go.GetComponent<FloorComponent>();

        floor.SetRoom(this);
    }

    public void RemoveFloor(FloorComponent floor)
    {
        Floors.Remove(floor);
    }

    public void GenerateCollider()
    {
        if (Floors.Count == 0)
            return;

        BoxCollider col = gameObject.GetComponent<BoxCollider>();

        Rect bounds = new Rect();

        foreach(FloorComponent floor in Floors)
        {
            Vector3 pos = floor.transform.localPosition;

            if (pos.x < bounds.xMin)
                bounds.xMin = pos.x;

            if (pos.x > bounds.xMin)
                bounds.xMax = pos.x;

            if (pos.z < bounds.yMin)
                bounds.yMin = pos.z;

            if (pos.z > bounds.yMax)
                bounds.yMax = pos.z;
        }

        Vector3 center = new Vector3(bounds.center.x, Roomheight/2, bounds.center.y);

        if(col == null)
            col = gameObject.AddComponent<BoxCollider>();

        col.center = center;
        col.size = new Vector3(bounds.size.x + TileSize, Roomheight, bounds.size.y + TileSize);

        col.isTrigger = true;

        Info.Center = center - Vector3.up * Roomheight / 2;
        Info.RoomWidth = (int)col.size.x;
        Info.RoomDepth = (int)col.size.z;
        if (Info.RoomName == string.Empty)
            Info.RoomName = name;
    }
}

[System.Serializable]
public class RoomInfo
{
    public string RoomName = "";
    public Vector3 Center;
    public int RoomWidth;
    public int RoomDepth;
}

[System.Serializable]
public class RoomEditorState
{
    public bool EditWalls = true;
    public bool EditFloors = true;

    [HideInInspector]
    public bool EditMode = true;
}
