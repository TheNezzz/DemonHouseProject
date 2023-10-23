using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomScript : MonoBehaviour
{
    public enum LightState { On, Flickering, Off }
    public LightState lightState;
    Demon demon;
    Light2D roomLight;
    bool demonInRoom = false;
    public float lightOutReq = 4f;
    float lightOutTimer;
    float flickerMaxIntensity = 1f;
    float flickerMinIntensity = 0.2f;
    float flickerTimeDif = 0.5f;

    private void Awake() {
        lightOutTimer = lightOutReq;
        lightState = LightState.On;
        roomLight = GetComponent<Light2D>();
        demon = FindObjectOfType<Demon>();
    }
    public void LightOn() {
        lightState = LightState.On;    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInParent<Demon>() != null) {
            demonInRoom = true;
            if (lightState == LightState.On) { 
            lightState = LightState.Flickering; 
        }
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.GetComponentInParent<Demon>() != null) {
            if (lightState == LightState.Flickering) { 
            lightOutTimer -= Time.deltaTime;
                if (lightOutTimer <= 0) {
                    lightState = LightState.Off;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponentInParent<Demon>() != null) {
            demonInRoom = false;
            if (lightState == LightState.Flickering) {
                lightOutTimer = lightOutReq;
                lightState = LightState.On;
            }
        }
    }

    private void Update() {
           if (lightState == LightState.On){
            roomLight.intensity = 1.75f;
        }
        
        
        if (lightState == LightState.Off){
            roomLight.intensity = 0f; 
        }


    }

}
