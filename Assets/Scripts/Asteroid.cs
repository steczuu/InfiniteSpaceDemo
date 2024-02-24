using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float speed,HP;
    private float selfDestructTime = 10f;
    private IEnumerator destroyAsteroid;

    private void Start() {
        speed = Random.Range(3f,9f);
        HP = Random.Range(30f,70f);

        destroyAsteroid = _destroyAsteroid(selfDestructTime);
        StartCoroutine(destroyAsteroid);
    }

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(HP <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GameManager.ResetScene();
            Debug.Log("Collison");
        }

        if(other.CompareTag("Bullet")){
            HP -= Random.Range(4f,10f);
            Debug.Log(HP);
        }
    }

    private IEnumerator _destroyAsteroid(float _time){
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
}
