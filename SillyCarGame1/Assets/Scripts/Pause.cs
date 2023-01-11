using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Move move;
    public bool menuActive = false;

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        move.Stop();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        move.Commence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActive = !menuActive;
            if (menuActive == true)
            {
                Paused();
            }
            if (menuActive == false)
            {
                Resume();
            }
        }
    }
}