using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularContact : MonoBehaviour
{
    public RoomManager Room;

    public ModularContact Contact;
    public int LayerMask =  1 << 20;

    public bool CheckContact()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.2f, LayerMask);

        if(cols.Length > 1)
        {
            foreach(Collider c in cols)
            {
                if(c.gameObject != gameObject)
                {
                    Contact = c.GetComponent<ModularContact>();
                    Contact.Contact = this;
                }
            }
        }

        return false;
    }

    public void GenerateWall(WallObjectDatabase database)
    {
        Vector3 pos = transform.position;
        GameObject wall = Instantiate(Room.WallPrefab, Room.transform);

        wall.transform.position = pos;
        wall.transform.rotation = transform.rotation;
        wall.GetComponent<WallComponent>().GenerateWall(database, WallObjectType.Straight);
    }

    public void GenerateFloor()
    {
        Vector3 pos = transform.parent.position + (-transform.forward * 3);
        GameObject go = Instantiate(Room.FloorPrefab, Room.transform);

        go.transform.position = pos;

        go.GetComponent<FloorComponent>().SetRoom(Room);
    }
}
