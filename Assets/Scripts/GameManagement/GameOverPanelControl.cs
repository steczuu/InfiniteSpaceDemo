using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverPanelControl : MonoBehaviour
{
   
    public Button restartBtn, MainMenuBtn, QuitBtn;
    void Start(){
        restartBtn.onClick.AddListener(RestartScene);
        MainMenuBtn.onClick.AddListener(ReturnToMenu);
        QuitBtn.onClick.AddListener(QuitGame);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
        GameManager.isPlayerDead = false;
    }

    public void RestartScene(){
        SceneManager.LoadScene(0);
        GameManager.isPlayerDead = false;
        GameManager.canAddPoints = true;
    }

}
