using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public GameObject GameManager;
    private GameManager gameManagerScript;
    public float speed = 5.0f;
    private Vector3 startPosition;
    private float repeatWidth;

    void Start() {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        gameManagerScript = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if(!gameManagerScript.gameOver) {
            if (transform.position.z < startPosition.z - repeatWidth) {
                transform.position = startPosition;
            }
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
