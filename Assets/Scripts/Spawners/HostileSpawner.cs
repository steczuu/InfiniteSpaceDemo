using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    public GameObject HostileObject;
    public Transform SpawnPos;
    [SerializeField]private float CooldownTime;
    [SerializeField]private float FirstWaveTimer;
    private IEnumerator SpawnObject;
    private bool canSpawn = false;


    private void Start() {
        CooldownTime = Random.Range(3f,10f);
        FirstWaveTimer = Random.Range(0f,10f);

        SpawnObject = ObjectCreation(FirstWaveTimer);
        StartCoroutine(SpawnObject);
    }

    void Update(){
        if(canSpawn){
            Instantiate(HostileObject, SpawnPos.position, transform.rotation);
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
