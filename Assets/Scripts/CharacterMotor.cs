using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    float MoveSpeed = 8;
    Animator Anim;
    CharacterController Controller;

    bool Typing;
    GameObject CurrentInteractable;

	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(!Typing)
            HandleMovement();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Typing)
            {
                Typing = false;
                GameObject.Find("LifeSupportPowerPanel").GetComponent<MenuBase>().Toggle();
            }
            else
            {
                if (CurrentInteractable != null)
                {
                    transform.rotation = CurrentInteractable.transform.rotation;
                    Typing = true;
                    StartCoroutine(OnShowConsole());
                }
            }
        }

        Anim.SetBool("IsTyping", Typing);
    }

    void HandleMovement()
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

        if(other.tag == "InteractableObject")
        {
            CurrentInteractable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FloorCameraTrigger")
        {
            Camera.main.cullingMask |= other.GetComponent<FloorVisibilityComponent>().Layers;
        }

        if (other.tag == "InteractableObject")
        {
            CurrentInteractable = null;
        }
    }

    IEnumerator OnShowConsole()
    {
        yield return new WaitForSeconds(0.75f);

        GameObject.Find("LifeSupportPowerPanel").GetComponent<MenuBase>().Toggle();

        yield return null;
    }
}
