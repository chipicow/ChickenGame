using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Wave;
    public Text HighScore;
    // Update is called once per frame
    void Awake()
    {
        Wave.text = "1";
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void Update()
    {
        Wave.text = GameController.instance.ChickenWave.ToString();
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
