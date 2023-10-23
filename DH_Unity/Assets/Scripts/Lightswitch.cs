using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lightswitch : MonoBehaviour, IInteractable
{
    RoomScript room;
    
    void Awake() {
        room = GetComponentInParent<RoomScript>();
    }

    public void Interact() {
        print("Flipped lightswitch");
        room.LightOn();
    }

    public string GetUIDescription() {
        return "";
    }
}
