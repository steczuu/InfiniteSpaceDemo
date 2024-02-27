using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static int points = 0;
    public static bool isPlayerDead = false;
    public static bool canAddPoints = true;
    public TMP_Text pointsText;
    public GameObject GameOverPanel,PointsText;

    private void Start() {
        GameOverPanel.SetActive(false);
    }

    private void Update(){
        pointsText.text = "Points: " + points.ToString();

        if(isPlayerDead){
            GameOverScreen();
        }
    }

    public static void AddPoints(){
        points++;
    }

    private void GameOverScreen(){
        GameOverPanel.SetActive(true);
        PointsText.SetActive(false);
        canAddPoints = false;
        points = 0;
    }
}
