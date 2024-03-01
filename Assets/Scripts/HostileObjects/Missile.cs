using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform player;
    private float speed = 6f,HP = 30f;
    public static bool isMissileSpawned;

    private void Start() {
        isMissileSpawned = true;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update(){
        MoveTowardsPlayer();

        if(HP <= 0){
            Destroy(gameObject);
            isMissileSpawned = false;
        }
    }

    void MoveTowardsPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            isMissileSpawned = false;
            GameManager.isPlayerDead = true;
        }
        if(other.CompareTag("Bullet")){
            HP -= 10f;
        }
    }
}
