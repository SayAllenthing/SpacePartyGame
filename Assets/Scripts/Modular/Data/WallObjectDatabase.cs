using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallObjectType
{
    None,
    Straight,
    Curved
}

public class WallObjectDatabase : ScriptableObject
{
    public List<WallObjectData> Objects = new List<WallObjectData>();
    public WallObjectData GetWallObect(WallObjectType type)
    {
        return Objects.Find(x => x.Type == type);
    }
}

[System.Serializable]
public class WallObjectData
{
    public WallObjectType Type;
    public GameObject Prefab;
}
