using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static int points = 0;
    public TMP_Text pointsText;

    private void Update(){
        pointsText.text = "Points: " + points.ToString();
    }

    public static void AddPoints(){
        points++;
    }

    public static void ResetScene(){
        SceneManager.LoadScene(0);
        points = 0;
    }
}
