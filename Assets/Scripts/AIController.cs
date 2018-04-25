using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent Agent;
    Animator Anim;

	// Use this for initialization
	void Start ()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = GameObject.Find("Character").transform.position;
            Agent.SetDestination(pos);
        }

        Anim.SetBool("IsWalking", Agent.velocity.magnitude > 0.1f);
    }
}
