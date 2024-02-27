using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : MonoBehaviour
{
    public Transform stoppingPointsObj;
    public List<Transform> stoppingPoints;
    private int pointsIndex = 0;
    private float speed = 7f,timeToMove = 3f,stopDist = 0.2f;
    public static bool dronesSpawned = false;
    public static float Hp = 30f;
    private bool canShoot;
    public Transform barrel;
    
    private void Start() {
        dronesSpawned = true;
        Debug.Log(dronesSpawned);
        InitializeRoute();
        MoveToNext();
    }

    void Update(){
        float distanceToPoint = Vector2.Distance(transform.position, stoppingPoints[pointsIndex].position);

        if(distanceToPoint < stopDist){
            MoveToNext();
        }
    }

    void InitializeRoute(){
        foreach (Transform child in stoppingPointsObj){
            stoppingPoints.Add(child);
        }
    }

    void MoveToNext(){
        if(stoppingPoints.Count == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, stoppingPoints[pointsIndex].position, speed*Time.deltaTime);

        pointsIndex = (pointsIndex + 1) % stoppingPoints.Count;
    }
}
