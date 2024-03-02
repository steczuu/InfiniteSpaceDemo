using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaineMenu : MonoBehaviour
{
    public Button playBtn,quitBtn;
    void Start(){
        playBtn.onClick.AddListener(PlayGame);
        quitBtn.onClick.AddListener(QuitGame);
    }

    private void PlayGame(){
        SceneManager.LoadScene(1);
    }

    private void QuitGame(){
        Application.Quit();
    }
}
