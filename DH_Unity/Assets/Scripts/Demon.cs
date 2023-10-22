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
    int nextWaypoint;
    public float navThreshold = 1f;
    Rigidbody rb;
    Vector3 lastSeenPlayerPos;
    //float stunTimer = 0f;
    public float StunTimeout = 4f;
    DemonFrontSensor sensorFront;
    public float roamSpeed = 1;
    public float chaseSpeed = 2f;
    public float detectionTime = 2f;
    public float detectionTimer = 0;


    private void Awake() {
        demonAI = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        sensorFront = GetComponent<DemonFrontSensor>();
        nextWaypoint = Random.Range(0, waypoints.Count);
        demonAI.destination = waypoints[nextWaypoint].position;
        
    }
    private void Update() {
        var playerVisible = sensorFront.TargetVisible();

        if (playerVisible == true) {
            detectionTimer += Time.deltaTime;
            if (detectionTimer >= detectionTime) {
                demonState = DemonState.Chasing;
                lastSeenPlayerPos = sensorFront.target.position;
                detectionTimer = 0f;
            }
        }
    }

    private void FixedUpdate() {

        if (demonState == DemonState.Roaming) {
            demonAI.speed = roamSpeed;
            if (Vector3.Distance(transform.position, waypoints[nextWaypoint].position) < navThreshold) {
                nextWaypoint = Random.Range(0, waypoints.Count);
                demonAI.destination = waypoints[nextWaypoint].position;
            }
        }else if (demonState == DemonState.Chasing) {
            demonAI.speed = chaseSpeed;
            demonAI.destination = sensorFront.target.position;
        }
    }    
    }



