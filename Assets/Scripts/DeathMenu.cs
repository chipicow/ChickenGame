using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Image backGroundImage;
    private bool dead;
    private float transition = 0.0f;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
            return;

        transition += Time.deltaTime;
        backGroundImage.color = Color.Lerp(new Color(0,0,0,0),Color.black,transition) ;
    }

    public void OnDeathMenu()
    {
        gameObject.SetActive(true);
        dead = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
