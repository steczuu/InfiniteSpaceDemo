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
            Vector2 position = new Vector2(startingPosition, transform.position.y);
            transform.position = position;
            
            if(GameManager.canAddPoints){
                GameManager.AddPoints();
            }
        }
    }
}
