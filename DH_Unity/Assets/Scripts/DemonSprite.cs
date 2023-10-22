using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSprite : MonoBehaviour
{
    Vector3 lastKnownPos;
    float dirTime = 0.5f;
    
    private void Awake() {
        lastKnownPos = transform.position;
        transform.localPosition = new Vector3(0, 0, -1);
    }
    private void Update() {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        dirTime -= Time.deltaTime;
        if (dirTime < 0) { 
            CheckFacing();
            dirTime = 0.5f;
        }
    }


    void CheckFacing() {
        var currentPos = transform.position;
        if (currentPos.x < lastKnownPos.x) {
            transform.localScale = new Vector3(-0.24f, 0.24f, 0.24f);
        }else if (currentPos.x > lastKnownPos.x) {
            transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
        }
        lastKnownPos = currentPos;
    }
}


