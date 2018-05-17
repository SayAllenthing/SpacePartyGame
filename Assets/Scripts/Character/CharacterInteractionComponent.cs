using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionComponent : MonoBehaviour
{
    public bool Interacting;
    GameObject CurrentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Interacting)
            {
                Interacting = false;
                CurrentInteractable.GetComponent<ModuleController>().Toggle();
            }
            else
            {
                if (CurrentInteractable != null)
                {
                    transform.rotation = CurrentInteractable.transform.rotation;
                    Interacting = true;
                    StartCoroutine(OnShowConsole());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractableObject")
        {
            CurrentInteractable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "InteractableObject")
        {
            CurrentInteractable = null;
        }
    }

    IEnumerator OnShowConsole()
    {
        yield return new WaitForSeconds(0.75f);
        
        CurrentInteractable.GetComponent<ModuleController>().Toggle();

        yield return null;
    }
}
