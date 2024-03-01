using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timeToShutdown = 10f,speed = 4f;
    private IEnumerator shutdownLaser;
    
    void Start(){
        shutdownLaser = _shutdownLaser(timeToShutdown);
        StartCoroutine(shutdownLaser);
    }

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(LaserGate.isDestroyed) Destroy(gameObject);
    }

    IEnumerator _shutdownLaser(float timer){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(other.gameObject);
        }
    }
}
