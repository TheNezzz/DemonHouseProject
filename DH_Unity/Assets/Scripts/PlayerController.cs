using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    Rigidbody rb;

    
    void Start() {
        rb = GetComponent<Rigidbody>();  
    }

    public void FixedUpdate() {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        var input = Vector3.right * hAxis + Vector3.up * vAxis;
        rb.MovePosition((Vector3)transform.position + (input * speed * Time.deltaTime));
        
    }
}

