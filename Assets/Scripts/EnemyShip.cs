using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject projectile;
    public Transform barrel;
    public Rigidbody2D player;
    public static float HP = 200f;
    private float speed, CooldownTime = 1.0f;
    private bool canShoot = true;


    void Update(){
        Move();
        ShootAtPlayer();

        if(HP <= 0){
            Destroy(gameObject);
        }
    }

    private void Move(){
        //search for better solution
        transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }

    private void ShootAtPlayer(){
        if(transform.position.y == player.transform.position.y && canShoot){
            Instantiate(projectile, barrel.position, transform.rotation);
            StartCoroutine(CooldownTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            HP -= Random.Range(10f,20f);
            Destroy(other.gameObject);
        }
    }

    IEnumerator CooldownTimer(){
        canShoot = false;
        yield return new WaitForSeconds(CooldownTime);
        canShoot = true;
    }
    
}
