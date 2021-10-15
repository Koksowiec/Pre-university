using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{

    public AudioSource audioSourceWalking;
    public AudioSource audioSourceRunning;

    bool isRunning;

    public float volumeRangeStart = .8f;
    public float volumeRangeStop = 1f;
    public float pitchRangeStart = .8f;
    public float pitchRangeStop = 1.1f;

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = GetComponent<PlayerMovement>().isRunning;
        if (cc.isGrounded == true && Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") && audioSourceWalking.isPlaying == false)//walking start
        {
            audioSourceWalking.volume = Random.Range(volumeRangeStart, volumeRangeStop);
            audioSourceWalking.pitch = Random.Range(pitchRangeStart, pitchRangeStop);
            audioSourceWalking.Play();
        }
        else if(cc.isGrounded == true && audioSourceRunning.isPlaying == false && isRunning == true)//running start
        {
            audioSourceWalking.Stop();
            audioSourceRunning.volume = Random.Range(volumeRangeStart, volumeRangeStop);
            audioSourceRunning.pitch = Random.Range(pitchRangeStart, pitchRangeStop);
            audioSourceRunning.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && audioSourceWalking.isPlaying)//walking stop
        {
            audioSourceWalking.Stop();
        }
        else if (audioSourceRunning.isPlaying && isRunning == false)//running stop
        {
            audioSourceRunning.Stop();
            audioSourceWalking.volume = Random.Range(volumeRangeStart, volumeRangeStop);
            audioSourceWalking.pitch = Random.Range(pitchRangeStart, pitchRangeStop);
            audioSourceWalking.Play();
        }
    }
}