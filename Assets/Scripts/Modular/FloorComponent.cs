using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorComponent : MonoBehaviour
{
    public GameObject Mesh;
    public List<ModularContact> Contacts = new List<ModularContact>();

    RoomManager Manager;

    public void SetRoom(RoomManager manager)
    {
        Manager = manager;
        Manager.Floors.Add(this);

        foreach(ModularContact contact in Contacts)
        {
            contact.Room = manager;
            contact.CheckContact();
        }
    }
}
