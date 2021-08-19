using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private float lowerBound = -15.0f;
    
    void Update()
    {
        if (transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
    }
}
