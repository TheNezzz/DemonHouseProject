using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class PlayerInteract : MonoBehaviour
{
    IInteractable interactable = null;
    public TMP_Text interactPrompt;


    private void OnTriggerEnter(Collider col) {
        var i = col.GetComponent<IInteractable>();
        if (i != null) {
            interactPrompt.text = "Press Space to Interact";
            print("Object interactable" + col.name);
            if (interactable != null) {
                Debug.LogError("Interactables too close in level.");
            }
            interactable = i;
        }
    }
    private void OnTriggerExit(Collider col) {
        interactable = null;
        interactPrompt.text = "";
    }

    private void Awake() {
        interactPrompt.text = "";
    }
    private void Update() {
        if (interactable != null) {
            if (Input.GetButtonDown("Jump")){
                interactable.Interact();
            }
        }
        
    }
}

