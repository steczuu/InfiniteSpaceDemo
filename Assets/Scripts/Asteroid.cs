using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float speed;
    private void Start() {
        speed = Random.Range(3f,8f);
    }

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") PlayerManager.isPlayerDead = true;
    }
}
