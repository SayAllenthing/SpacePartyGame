using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDisasterManager : MonoBehaviour
{
    public List<StationController> Consoles = new List<StationController>();

    public float NextDisasterTime = 5;
	// Use this for initialization
	void Start ()
    {
        Consoles.AddRange(FindObjectsOfType<StationController>());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time > NextDisasterTime)
        {
            int rand = Random.Range(0, Consoles.Count);
            Consoles[rand].TakeDamage(Random.Range(15, 25));

            NextDisasterTime += Random.Range(1, 2);
        }
	}
}
