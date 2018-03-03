using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Wave;
    public Text WaveOnDeath;
    public Text HighScoreOnDeath;
    // Update is called once per frame
    void Awake()
    {
        Wave.text = "1";
    }
    void Update()
    {
        Wave.text = GameController.instance.ChickenWave.ToString();
        WaveOnDeath.text = GameController.instance.ChickenWave.ToString();
        HighScoreOnDeath.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
