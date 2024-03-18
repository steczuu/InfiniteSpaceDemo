using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drones : MonoBehaviour
{
    PrefabsData prefabsData = new PrefabsData();
    public List<Transform> stoppingPoints = new List<Transform>();
    private int randomPoint;
    private float speed = 5.5f,UpdateTime, StartingTime = 1.5f,ShootCooldownTime = 1f;
    public static bool dronesSpawned = false;
    public static float Hp = 50f;
    private bool canShoot = true;
    public Transform barrel;
    public GameObject bullet;
    public AudioSource audioSource;
    
    private void Start() {
        //stoppingPoints.AddRange(prefabsData.dronePoints.ToList());

        randomPoint = Random.Range(0, stoppingPoints.Count);
        UpdateTime = StartingTime;
        dronesSpawned = true;
        Debug.Log(dronesSpawned);
    }

    void Update(){
        if(canShoot){
            Shoot();
            StartCoroutine(CooldownTimer());
        }

        if(Hp <= 0f){
            Destroy(gameObject);
            DroneSpawnerTest.HasSpawned = false;
            audioSource.Play();
        }

        transform.position = Vector2.MoveTowards(transform.position, stoppingPoints[randomPoint].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, stoppingPoints[randomPoint].position) < 0.2f){
            if(UpdateTime <= 0 ){
                randomPoint = Random.Range(0, stoppingPoints.Count);
                UpdateTime = StartingTime;
            }else{
                UpdateTime -= Time.deltaTime;
            }
        }
    }
     
    void Shoot(){
        Instantiate(bullet, barrel.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            Hp -= 10f;
        }
    }

    IEnumerator CooldownTimer(){
        canShoot = false;
        yield return new WaitForSeconds(ShootCooldownTime);
        canShoot = true;
    }
}
