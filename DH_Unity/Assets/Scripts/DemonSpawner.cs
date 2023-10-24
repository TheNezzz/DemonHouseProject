using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{
    public Transform[] spawns;
    public RoomScript[] spawnRooms;
    public float spawnTimer = 5f;
    bool playerInStart = true;
    Demon demon;
    int spawnIndex;

    private void Awake() {
        demon = FindObjectOfType<Demon>();
        demon.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<PlayerController>() != null) {
            //UI tooltip to help open the book

        }
    }


    private void OnTriggerExit(Collider other) {
        if (playerInStart) {
            if (other.GetComponent<PlayerController>() != null) {
                playerInStart = false;
                spawnIndex = Random.Range(0, spawns.Length);
                demon.transform.position = spawns[spawnIndex].transform.position;
                spawnRooms[spawnIndex].lightState = RoomScript.LightState.Flickering;
            }
        }
    }

    private void Update() {
        if (playerInStart == false) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0 ) {
                demon.gameObject.SetActive(true);
                spawnRooms[spawnIndex].lightState = RoomScript.LightState.Off;

            }
        }
    }
}


