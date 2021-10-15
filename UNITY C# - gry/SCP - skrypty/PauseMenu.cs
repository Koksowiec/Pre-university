using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject blinkingUI;

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenuUI;

    public AudioSource buttonClick;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //sound
        buttonClick.Play();

        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);

        //resume time
        Time.timeScale = 1f;

        isPaused = false;

        //widocznoscc myszki
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //enable blinking
        blinkingUI.GetComponent<Blinking>().enabled = true;
    }

    public void Pause()
    {
        //disable blinking
        blinkingUI.GetComponent<Blinking>().enabled = false;

        pauseMenuUI.SetActive(true);

        //stop time
        Time.timeScale = 0f;

        isPaused = true;

        //widocznoscc myszki
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Options()
    {
        //sound
        buttonClick.Play();

        //pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        //sound
        buttonClick.Play();

        Time.timeScale = 1f;
        SceneManager.LoadScene("MENU");
    }

    public void QuitGame()
    {
        //sound
        buttonClick.Play();

        Debug.Log("Quit");
        Application.Quit();
    }
}
