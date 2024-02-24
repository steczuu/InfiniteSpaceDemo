using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    private float rotationSpeed;
    
    void Start() {
        rotationSpeed = Random.Range(1f,6f);
    }
 
    void Update(){
        transform.Rotate(rotationSpeed * 0,0,20 * Time.deltaTime);
    }
}
