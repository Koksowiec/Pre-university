using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject deathMenuUI;

    public void DeathPause()
    {
        //disable pause menu
        pauseMenu.GetComponent<PauseMenu>().enabled = false;

        deathMenuUI.SetActive(true);

        //stop time
        Time.timeScale = 0f;

        //widocznoscc myszki
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;       
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");

        //enable pause menu
        //GetComponent<PauseMenu>().enabled = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MENU");
    }
}
