using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform Target;
    public Camera Cam;

    public Vector3 Offset;

	// Use this for initialization
	void Start () {
		
	}

	public void SetTarget(Transform t)
	{
		Target = t;
		Cam.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Target == null)
			return;

		transform.position = Target.position + Offset;        
    }
}
