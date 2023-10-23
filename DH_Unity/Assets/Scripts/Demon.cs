using System.Collections;
using System.Collections.Generic;
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
    float stunTimer = 0f;
    public float StunTimeout = 4f;
    DemonFrontSensor sensorFront;
    public float startingRoamSpeed = 1f;
    float roamSpeed = 1f;
    public float startingChaseSpeed = 2f; 
    float chaseSpeed = 2f;
    public float detectionTime = 2f;
    public float detectionTimer = 0;

    int darkRooms = 0;
    public float speedMultiplier = 0.1f;


    private void Awake() {
        demonAI = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        sensorFront = GetComponent<DemonFrontSensor>();
        nextWaypoint = Random.Range(0, waypoints.Count);
        demonAI.destination = waypoints[nextWaypoint].position;
        
    }

    public void NewDarkRoom() {
        darkRooms++;
        roamSpeed = startingRoamSpeed + (darkRooms * speedMultiplier);
        chaseSpeed = startingChaseSpeed + (darkRooms * speedMultiplier);
    }

    public void LightRoom() {
        roamSpeed = startingRoamSpeed + (darkRooms * speedMultiplier);
        chaseSpeed = startingChaseSpeed + (darkRooms * speedMultiplier);
        darkRooms--;
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
        if (demonState == DemonState.Stunned) {
            stunTimer += Time.deltaTime;
            demonAI.speed = 0f;
            if (stunTimer >= StunTimeout) {
                demonState = DemonState.Roaming;
                nextWaypoint = Random.Range(0, waypoints.Count);
                demonAI.destination = waypoints[nextWaypoint].position;
                stunTimer = 0f;
            }
        }
        else if (demonState == DemonState.Roaming) {
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



