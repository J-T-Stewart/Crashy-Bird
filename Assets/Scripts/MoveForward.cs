using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
    
    public float baseSpeed;
    private float speed;
    private GameManager GameManagerScript;

    void Start() {
        GameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        speed = baseSpeed;
    }

    void Update() {
        speed = baseSpeed + GameManagerScript.playerScore / 10;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
