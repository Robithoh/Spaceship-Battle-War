using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting.Antlr3.Runtime;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timeText;
    public Text scoreText;
    public float spawnTime;
    public static bool gameEnding = false;

    public GameObject SuccesMenu;
    public GameObject spawner1;
    public GameObject spawner2;

    int score = 0;
    bool isCreated;
    void Start()
    {
        Time.timeScale = 1;
        SuccesMenu.active = false;
        scoreText = GetComponent<Text>();
    }
    void Update()
    {
        scoreText.text = "Score : " + Ship.ScoreUlt;
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
        if (!isCreated)
        {
                if (timeValue <= spawnTime)
                {
                    Instantiate(spawner1, new Vector3(18.67f, 1.69f, 0), Quaternion.identity);
                    Instantiate(spawner2, new Vector3(17.09f, -2.62f, 0), Quaternion.identity);
                isCreated = true;
                }
            if (timeValue <= 5)
            {
                Destroy(spawner1);
                Destroy(spawner2);
            }
        }

        if (timeValue < 0)
        {
            gameEnd();
        }
    }
    public void gameEnd()
    {
        if (gameEnding)
        {
            AudioListener.pause = false;
            Time.timeScale = 1;
            SuccesMenu.active = false;
        }
        else
        {
            AudioListener.pause = true;
            Time.timeScale = 0;
            SuccesMenu.active = true;
        }
    }
    public void gameStart()
    {
      
    }
    void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
    }
 
}
