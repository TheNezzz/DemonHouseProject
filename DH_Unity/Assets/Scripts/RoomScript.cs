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
    public float flickerMaxIntensity = 1f;
    public float flickerMinIntensity = 0.2f;
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    private void Awake() {
        smoothQueue = new Queue<float>(smoothing);
        lightOutTimer = lightOutReq;
        lightState = LightState.On;
        roomLight = GetComponent<Light2D>();
        demon = FindObjectOfType<Demon>();
    }
    public void LightOn() {
        lightState = LightState.On;   
        if (demonInRoom) {
            demon.demonState = Demon.DemonState.Stunned;
        }
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
        while (smoothQueue.Count >= smoothing) {
            lastSum -= smoothQueue.Dequeue();
        }
            if (lightState == LightState.On){
            roomLight.intensity = 1.75f;
        }else if (lightState == LightState.Flickering) {
            float newVal = Random.Range(flickerMinIntensity, flickerMaxIntensity);
            smoothQueue.Enqueue(newVal);
            lastSum += newVal;

            roomLight.intensity = lastSum / smoothQueue.Count;
        }

        if (lightState == LightState.Off){
            roomLight.intensity = 0f; 
        }

    }

}
