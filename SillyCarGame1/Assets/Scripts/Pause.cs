using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public float pitchValue = 1.0f;
    public AudioSource audioSource;
    public bool menuActive = false;

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Resume();
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pitchValue = 0.75f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pitchValue = 1.0f;
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
    void OnGUI()
    {
        pitchValue = pitchValue;
        audioSource.pitch = pitchValue;
    }

}
    