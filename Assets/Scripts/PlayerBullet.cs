using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private IEnumerator destroyProjectile;
    private float time = 5f;

    private void Start() {
        destroyProjectile = _destroyProjectile(time);
        StartCoroutine(destroyProjectile);
    }

    private void Update() {
        transform.Translate(Vector2.right * 7f * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator _destroyProjectile(float timeToDestroy){
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
