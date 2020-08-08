using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float sSpeed = 1000.0f;
    private Vector3 dist = new Vector3(0, 2, -15);

    private void Update() {
        Vector3 dPos = target.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(target.position);    
    }

}
