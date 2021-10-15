using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    public GameObject startGameUI;
    bool isTrigger;
    bool isActive = false;

    //end game
    public GameObject deathMenuUI;

    //Plot element
    public GameObject image;
    public Animator transition;
    public float transmitionTime = 10f;
    public AudioSource alarmAudioSource;

    //go to scene index number
    public int sceneNumber = 2;

    //some safty measures
    public PauseMenu pauseMenu;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    //Add this to make loading screen
    public GameObject loadingScreen;
    public Slider slider;

    private void Start()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        mouseLook = GameObject.FindObjectOfType<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true && deathMenuUI == null)
        {
            pauseMenu.enabled = false;
            playerMovement.enabled = false;

            //Loading screen
            startGameUI.SetActive(false);

            //StartCoroutine(LevelTransition());
            
            LoadLevel(sceneNumber);
        }
        else if(Input.GetKeyDown(KeyCode.E) && isActive == true && deathMenuUI != null)
        {
            pauseMenu.enabled = false;
            playerMovement.enabled = false;
            mouseLook.enabled = false;

            //widocznoscc myszki
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            alarmAudioSource.Play();
            StartCoroutine(LevelTransition());
            deathMenuUI.SetActive(true);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;

        if (isActive == true)
        {
            startGameUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;

        isActive = false;

        if (isActive == false)
        {
            startGameUI.SetActive(false);
        }
    }

    //Loading screen

    public void LoadLevel(int sceneIndex)
    {
        
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //transition with sound
        image.SetActive(true);
        transition.SetTrigger("Start");
        alarmAudioSource.Play();
        yield return new WaitForSeconds(transmitionTime);
        image.SetActive(false);

        //next scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    IEnumerator LevelTransition()
    {
        image.SetActive(true);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transmitionTime);
    }

}
