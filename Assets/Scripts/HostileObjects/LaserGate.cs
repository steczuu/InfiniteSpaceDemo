using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour
{
    private IEnumerator selfDestruct;
    private float speed = 4f,time =10f,Hp = 40f;
    public GameObject laser;
    private bool canActivateLaser = true;
    public Transform spawnPos;
    public static bool isSpawned,isDestroyed;

    
    void Start(){ 
        isSpawned = true;
        isDestroyed = false;
        selfDestruct = _selfDestruct(time);
        StartCoroutine(selfDestruct); 
    }

    
    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(canActivateLaser){
            Instantiate(laser, spawnPos.position, transform.rotation);
            canActivateLaser = false;
        }

        if(Hp <=0){
            Destroy(gameObject);
            isDestroyed = true;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Bullet")){
            Hp -= 5f; 
            Debug.Log(Hp);
        }
    }

    IEnumerator _selfDestruct(float timer){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
        isSpawned = false;
        isDestroyed = true;
    }
}
