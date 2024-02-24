using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private IEnumerator destroyProjectile;
    private float time = 5f;

    private void Start() {
        destroyProjectile = _destroyProjectile(time);
        StartCoroutine(destroyProjectile);
    }

    private void Update() {
        transform.Translate(Vector2.left * 7f * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator _destroyProjectile(float timeToDestroy){
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
