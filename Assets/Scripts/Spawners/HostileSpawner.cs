using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    public GameObject[] HostileObjects;
    public Transform SpawnPos;
    [SerializeField]private float CooldownTime;
    [SerializeField]private float FirstWaveTimer;
    private IEnumerator SpawnObject;
    private bool canSpawn = false;
    public bool isLaserSpawner,isMissileSpawner,isAsteroidSpawner;


    private void Start() {
        CooldownTime = Random.Range(3f,12f);
        FirstWaveTimer = Random.Range(0f,10f);

        SpawnObject = ObjectCreation(FirstWaveTimer);
        StartCoroutine(SpawnObject);
    }

    void Update(){
        if(canSpawn && isAsteroidSpawner){
            Instantiate(HostileObjects[0], SpawnPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
        }

        if(canSpawn && isLaserSpawner){
            Instantiate(HostileObjects[1], SpawnPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
        }

        if(canSpawn && isMissileSpawner && !Drones.dronesSpawned && GameManager.points > 10){
            Instantiate(HostileObjects[2], SpawnPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
        }
    }

    IEnumerator CooldowTimer(){
        canSpawn = false;
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
    }

    private IEnumerator ObjectCreation(float firstWaveTimer){
        yield return new WaitForSeconds(firstWaveTimer);
        canSpawn = true;
    }
}
