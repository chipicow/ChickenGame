using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Wave;
    // Update is called once per frame
    void Awake()
    {
        Wave.text = "1";
    }
    void Update()
    {
        Wave.text = GameController.instance.ChickenWave.ToString();
    }
}
