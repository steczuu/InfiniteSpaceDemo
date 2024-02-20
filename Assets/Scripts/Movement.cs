using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Vspeed = 5f;

    void Update(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) transform.Translate(Vector2.up * Vspeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) transform.Translate(Vector2.down * Vspeed * Time.deltaTime);
    }
}   
