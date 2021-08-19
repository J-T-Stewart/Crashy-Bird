using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    public bool followMouse;
    public Camera Camera;
    public float speed = 10.0f;
    private float xRange = 4f;
    private float screenWidth = Screen.width;

    void Update() {
        if (followMouse) {
            FollowMouse();
        } else {
            TouchMove();
        }
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void TouchMove() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x > screenWidth / 2) {
                transform.Translate(speed, 0, 0);
            } else if (mousePos.x < screenWidth / 2 - 0.01) {
                transform.Translate(-speed, 0, 0);
            }
        }
    }

    void FollowMouse() {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Vector3 myPoint = hit.point;
                myPoint.y = 1;
                myPoint.z = -9;
                Debug.Log("Point: " + myPoint);
                transform.position = myPoint;
            }
        }
    }
}
