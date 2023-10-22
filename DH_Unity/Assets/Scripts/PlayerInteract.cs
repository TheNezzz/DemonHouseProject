using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    IInteractable interactable = null;


    private void OnTriggerEnter(Collider col) {
        var i = col.GetComponent<IInteractable>();
        if (i != null) {
            print("Object interactable" + col.name);
            if (interactable != null) {
                Debug.LogError("Interactables too close in level.");
            }
            interactable = i;
        }
    }

    private void OnTriggerExit(Collider col) {
        interactable = null;
    }

    private void Update() {
        if (interactable != null) {
            if (Input.GetButtonDown("Jump")){
                interactable.Interact();
            }
        }
        
    }
}

