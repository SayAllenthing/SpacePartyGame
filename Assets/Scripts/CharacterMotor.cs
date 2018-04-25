using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    float MoveSpeed = 8;
    Animator Anim;
    CharacterController Controller;

	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        if (dir.magnitude > 1)
            dir.Normalize();

        Controller.Move(((dir * MoveSpeed) + Physics.gravity) * Time.deltaTime);
        transform.LookAt(transform.position + dir);

        Anim.SetBool("IsWalking", dir.magnitude > 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FloorCameraTrigger")
        {
            Camera.main.cullingMask = ~other.GetComponent<FloorVisibilityComponent>().Layers;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FloorCameraTrigger")
        {
            Camera.main.cullingMask |= other.GetComponent<FloorVisibilityComponent>().Layers;
        }
    }
}
