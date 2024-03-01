using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float startingPosition, offScreenPosition;
    public static bool haveTransformedPos;


    void Update(){
        transform.Translate(Vector2.left * 3f * Time.deltaTime);

        if(transform.position.x <= offScreenPosition){
            Vector3 position = new Vector3(startingPosition, transform.position.y,transform.position.z);
            transform.position = position;
            
            if(GameManager.canAddPoints){
                GameManager.AddPoints();
            }
        }
    }
}
