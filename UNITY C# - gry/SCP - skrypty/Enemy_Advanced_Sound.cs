using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Advanced_Sound : MonoBehaviour
{

    //sounds
    public AudioSource enemyAudioSource;
    public float volumeSound = 1f;
    public float pitchSound = 1f;

    bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger == true)
        {
            enemyAudioSource.volume = volumeSound;
            enemyAudioSource.pitch = pitchSound;
            enemyAudioSource.Play();
        }
        else
        {
            enemyAudioSource.Pause();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }
}
