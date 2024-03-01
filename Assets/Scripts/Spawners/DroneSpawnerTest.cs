using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawnerTest : MonoBehaviour
{
    private float CooldownTime,FirstWaveTimer;
    private IEnumerator SpawnObject;
    bool canSpawn = false;
    public static bool HasSpawned = false;
    public Transform HostileObject,SpawnPos;
    
    private void Start() {
        CooldownTime = Random.Range(3f,10f);
        FirstWaveTimer = Random.Range(0f,10f);

        SpawnObject = ObjectCreation(FirstWaveTimer);
        StartCoroutine(SpawnObject);
    }

    void Update(){
        if(HasSpawned) canSpawn = false;

        if(canSpawn && !Missile.isMissileSpawned && GameManager.points > 5){
            Instantiate(HostileObject, SpawnPos.position, Quaternion.identity);
            HasSpawned = true;
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
