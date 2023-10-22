using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFrontSensor : MonoBehaviour
{
    public Transform target;
    bool targetVisible = false;
    public float maxDistance = 5f;
    public float maxAngle = 45f;
    public LayerMask sightBlockers;

    public bool TargetVisible() {
        return targetVisible;
    }

    void UpdateVisible() {
        targetVisible = false;
        if (Vector3.Distance(transform.position, target.position) > maxDistance) {
            return;
        }
        var d = target.position - transform.position;
        var angle = Vector3.Angle(d, transform.forward);
        if (angle > maxAngle) {
            return;   
        }
        RaycastHit hit;
        var heightShift = Vector3.up * 1f;
        if (Physics.Raycast(transform.position + heightShift,
            d, out hit, d.magnitude, sightBlockers)) {
            Debug.DrawLine(transform.position + heightShift, hit.point, Color.red);
        }
        else {
            Debug.DrawLine(transform.position + heightShift, target.position + heightShift, Color.cyan);

        }
        targetVisible = true;
        print("Player visible.");

    }

    void DrawAngleLines() {
        var p = transform.position;
        var fwd = transform.forward * maxDistance;
        var rotLeft = Quaternion.Euler(0, 0, maxAngle);
        var rotRight = Quaternion.Euler(0, 0, -maxAngle);
        var leftVec = rotLeft * fwd;
        var rightVec = rotRight * fwd;
        Debug.DrawLine(p, p + leftVec, Color.yellow);
        Debug.DrawLine(p, p + rightVec, Color.yellow);

    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    private void Update() {
        UpdateVisible();
        DrawAngleLines();
    }
}
