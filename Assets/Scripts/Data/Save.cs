using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Save : MonoBehaviour
{
    [SerializeField] private HighScoreData _data = new HighScoreData();

    public void SaveToJson(){
        string score = JsonUtility.ToJson(_data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/HighscoreData.json", score);
    }
}

[System.Serializable]
public class HighScoreData{
    public int value = GameManager.points;
}
