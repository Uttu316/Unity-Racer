using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UImanager : MonoBehaviour {
    public Text scoreText;
    public Button[] buttons;
    public Button button;
    int score;
    public audiomanager pm;
    bool gameOver;
	// Use this for initialization
	void Start () {
        score = 0;
        gameOver = false;
        InvokeRepeating("scoreUpdate", 1.5f, 1.5f);
	}
	void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }
   public void Play()
    {
        Application.LoadLevel(1);
    }
    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;

       
	}
    public void Pause()
    {
        if (Time.timeScale==1)
        {
          //  pm.carSound.Stop();
            Time.timeScale = 0;
           
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
       
    }
    public void Replay()
    {
        Application.LoadLevel("level 1");
    }
    public void Menu()
    {
        Application.LoadLevel(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
