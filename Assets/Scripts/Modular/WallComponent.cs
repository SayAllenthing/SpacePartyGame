using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallComponent : MonoBehaviour
{
    public GameObject WallObject;

    [HideInInspector]
    public WallObjectType Type;

    public void GenerateWall(WallObjectDatabase database, WallObjectType type)
    {
        Type = type;

        if (WallObject != null)
            DestroyImmediate(WallObject);

        WallObject = Instantiate(database.GetWallObect(type).Prefab, transform);
    }
}


