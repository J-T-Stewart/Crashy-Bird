using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public GameObject GameManager;
    public ParticleSystem playerHit;
    public ParticleSystem playerDeath;
    public ParticleSystem TokenCollect;

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        if (other.tag == "Point") {
            GameManager.GetComponent<GameManager>().CollectPoint();
            TokenCollect.Play();
        } else if (other.tag == "Hazard") {
            GameManager.GetComponent<GameManager>().HitHazard();
            if (GameManager.GetComponent<GameManager>().gameOver) {
                playerDeath.Play();
            } else {
                playerHit.Play();
            }   
        }
    }
}
