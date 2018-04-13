using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject WallPrefab;

    public MeshRenderer Floor;

    List<GameObject> LeftWalls = new List<GameObject>();
    List<GameObject> RightWalls = new List<GameObject>();
    List<GameObject> FrontWalls = new List<GameObject>();
    List<GameObject> BackWalls = new List<GameObject>();

    int TileSize = 3;

    public void GenerateWalls(WallObjectDatabase database)
    {
        
        float up = Floor.bounds.extents.y;

        //Front
        float leftPos = Floor.bounds.extents.x;
        Vector3 pos = new Vector3(0, 0, -leftPos);
        GameObject wall = Instantiate(WallPrefab, transform);
        wall.transform.localPosition = pos + Vector3.up * up;

        //Left
        pos = new Vector3(leftPos, 0, 0);
        GameObject wall2 = Instantiate(WallPrefab, transform);
        wall2.transform.localPosition = pos + Vector3.up * up;
        wall2.transform.LookAt(wall2.transform.position - pos);


        wall.GetComponent<WallComponent>().GenerateWall(database, WallObjectType.Curved);
        wall2.GetComponent<WallComponent>().GenerateWall(database, WallObjectType.Curved);
    }
}
