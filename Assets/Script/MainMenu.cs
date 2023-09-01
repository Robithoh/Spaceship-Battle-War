using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string ScenetoLoad;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Contiune()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingMenu");
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene("Menu");
        AudioListener.pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Retry()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Retry1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioListener.pause = false;

    }

    IEnumerator musicPause()
    {
        yield return new WaitForSeconds(1);
        AudioListener.pause = false;
    }
}
