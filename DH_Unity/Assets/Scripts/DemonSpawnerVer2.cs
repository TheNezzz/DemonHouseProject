using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemonSpawnerVer2 : MonoBehaviour
{
    public Transform[] spawns;
    public RoomScript[] spawnRooms;
    public TMP_Text tooltip;
    //public float spawnTimer = 5f;
    bool playerInStart = true;
    Demon demon;
    int spawnIndex;

    private void Start() {
        demon = FindObjectOfType<Demon>();
        //demon.gameObject.SetActive(false);
        spawnIndex = Random.Range(0, spawns.Length);
        demon.transform.position = spawns[spawnIndex].transform.position;
        spawnRooms[spawnIndex].lightState = RoomScript.LightState.Flickering;
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<PlayerController>() != null) {
            if (playerInStart){
                demon.GracePeriod();
            }
            //UI tooltip to help open the book
            if (Input.GetKey(KeyCode.Tab)) {
                tooltip.text = string.Empty;
            }
        }
    }


    private void OnTriggerExit(Collider other) {
        if (playerInStart) {
            if (other.GetComponent<PlayerController>() != null) {
                
                playerInStart = false;
                //demon.gameObject.SetActive(true);
                //spawnRooms[spawnIndex].lightState = RoomScript.LightState.Off;
                tooltip.text = string.Empty;
            }
        }
    }

    //private void FixedUpdate() {
    //    if (playerInStart == false) {
    //        spawnTimer -= Time.deltaTime;
    //        if (spawnTimer < 0 ) {
    //            spawnTimer = 0;
    //            demon.gameObject.SetActive(true);
    //            spawnRooms[spawnIndex].lightState = RoomScript.LightState.Off;


    //        }
    //    }
    //}
}


