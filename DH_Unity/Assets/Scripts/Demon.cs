using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Demon : MonoBehaviour
{
    public enum DemonState { Roaming, Chasing, Stunned}
    public DemonState demonState = DemonState.Roaming;
    NavMeshAgent demonAI;
    public List<Transform> waypoints;
    int nextWaypoint = 0;
    public float navThreshold = 1f;
    Rigidbody rb;
    Vector3 lastSeenPlayerPos;
    //float stunTimer = 0f;
    public float StunTimeout = 4f;
    DemonFrontSensor sensorFront;
    DemonRearSensor sensorRear;

    private void Awake() {
        demonAI = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        sensorFront = GetComponent<DemonFrontSensor>();
        sensorRear = GetComponent<DemonRearSensor>();
        demonAI.destination = waypoints[nextWaypoint].position;

    }
    private void Update() {
        var playerVisible = sensorFront.TargetVisible();

        if (playerVisible == true) {
            demonState = DemonState.Chasing;
            lastSeenPlayerPos = sensorFront.target.position; 
        }
    }

    private void FixedUpdate() {

        if (demonState == DemonState.Roaming) {
            if (Vector3.Distance(transform.position, waypoints[nextWaypoint].position) < navThreshold) {
                nextWaypoint++;
                if (nextWaypoint == waypoints.Count) {
                    nextWaypoint = 0;
                }
                demonAI.destination = waypoints[nextWaypoint].position;
            }
        }else if (demonState == DemonState.Chasing) {
            demonAI.destination = lastSeenPlayerPos;
        }
    }    
    }



