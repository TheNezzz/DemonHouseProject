using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lightswitch : MonoBehaviour
{
    public bool switchOn = true;
    public GameObject lightBulb;

    private void Awake() {
        
    }


    private void OnTriggerEnter(Collider other) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
        }
    }
}
