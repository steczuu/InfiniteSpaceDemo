using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public Transform SpawnPos;
    private float CooldownTime;
    private float FirstWaveTimer;
    private IEnumerator SpawnAsteroid;
    private bool canSpawn = false;


    private void Start() {
        CooldownTime = Random.Range(0f,10f);
        FirstWaveTimer = Random.Range(0f,10f);

        SpawnAsteroid = AsteroidCreation(FirstWaveTimer);
        StartCoroutine(SpawnAsteroid);
    }

    void Update(){
        if(canSpawn){
            Instantiate(Asteroid, SpawnPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
        }
    }

    IEnumerator CooldowTimer(){
        canSpawn = false;
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
    }

    private IEnumerator AsteroidCreation(float firstWaveTimer){
        yield return new WaitForSeconds(firstWaveTimer);
        canSpawn = true;
    }
}
