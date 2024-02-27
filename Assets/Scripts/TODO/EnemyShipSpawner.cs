using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShipSpawner : MonoBehaviour
{
    
    public GameObject ship;
    public Transform SpawnPos;
    private bool isSpawned;


    void Update() {
        if(GameManager.points == 3 && !isSpawned) Spawn();
        if(EnemyShip.HP <=0) isSpawned = false;  
    }

    void Spawn(){
        Instantiate(ship, SpawnPos.position, transform.rotation); 
        isSpawned = true;
    }
}
