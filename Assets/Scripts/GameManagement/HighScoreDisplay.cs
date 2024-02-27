using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HighScoreDisplay : MonoBehaviour
{
    private int Highscore;
    public TMP_Text highScoreTxt;

    void Update(){
        if(GameManager.points > Highscore){
            Highscore = GameManager.points;
        }

        highScoreTxt.text = "Highscore: " + Highscore.ToString();
    }
}
