using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Vspeed = 5f;
    public float MaxY_Pos,MinY_Pos;

    void Update(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position.y < MaxY_Pos) 
            transform.Translate(Vector2.up * Vspeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > MinY_Pos) 
            transform.Translate(Vector2.down * Vspeed * Time.deltaTime);
    }
}   
