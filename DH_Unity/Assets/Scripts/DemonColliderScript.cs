using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonColliderScript : MonoBehaviour
{
    GameManager gameManager;


    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            gameManager.Death();
        }
    }

}


