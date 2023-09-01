using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenu;

    PauseAction action;

    private void Awake()
    {
        {
            action = new PauseAction();
        }
    }
    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }
    private void DeterminePause()
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;
        pauseMenu.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        AudioListener.pause = false ;
        pauseMenu.SetActive(false);
    }
}
