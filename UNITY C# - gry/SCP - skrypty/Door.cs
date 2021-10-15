using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorsUI;
    public GameObject Doors;

    Animator _animator;

    bool isTrigger;
    bool isActive = false;

    public AudioSource doorAudioSource;
    public float volumeSound = 1f;
    public float pitchSound = 1f;

    //karty
    public string cardColour;

    public Card yellowCard;
    public Card blueCard;
    public Card redCard;

    GameObject yellowCardObj;
    GameObject blueCardObj;
    GameObject redCardObj;

    public GameObject doorsUIyellow;
    public GameObject doorsUIblue;
    public GameObject doorsUIred;

    private void Start()
    {
        _animator = gameObject.GetComponentInChildren<Animator>();

        //karta = GameObject.Find("YellowCard(Clone)");

        //card = karta.GetComponent<Card>();


        //karta = GameObject.Find("YellowCard(Clone)");
        //card = karta.GetComponent<Card>();

        Invoke("FindCard", 2f);

    }

    void FindCard()
    {
        yellowCardObj = GameObject.Find("YellowCard(Clone)");
        yellowCard = yellowCardObj.GetComponent<Card>();

        blueCardObj = GameObject.Find("BlueCard(Clone)");
        blueCard = blueCardObj.GetComponent<Card>();

        redCardObj = GameObject.Find("RedCard(Clone)");
        redCard = redCardObj.GetComponent<Card>();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R) && isActive == true && doorAudioSource.isPlaying == false)
        {
            doorAudioSource.volume = volumeSound;
            doorAudioSource.pitch = pitchSound;
            doorAudioSource.Play();

            //Animator _animator = gameObject.GetComponentInChildren<Animator>();
            _animator.SetBool("isTrigger", true);
            _animator.SetTrigger("OpenClose");
        }
        */

        //card = karta.GetComponent<Card>();


        if (cardColour == "yellow")
        {

            //Debug.Log(yellowStatus);

            if (Input.GetKeyDown(KeyCode.R) && isActive == true && doorAudioSource.isPlaying == false && /*card.yellowCard*/ yellowCard.yellowCard == true)
            {
                doorAudioSource.volume = volumeSound;
                doorAudioSource.pitch = pitchSound;
                doorAudioSource.Play();

                //Animator _animator = gameObject.GetComponentInChildren<Animator>();
                _animator.SetBool("isTrigger", true);
                _animator.SetTrigger("OpenClose");
            }
            else
            {
                //Debug.Log("Nie mozesz tu wejsc");
            }
        }
        else if(cardColour == "blue")
        {

            if (Input.GetKeyDown(KeyCode.R) && isActive == true && doorAudioSource.isPlaying == false && blueCard.blueCard == true)
            {
                doorAudioSource.volume = volumeSound;
                doorAudioSource.pitch = pitchSound;
                doorAudioSource.Play();

                //Animator _animator = gameObject.GetComponentInChildren<Animator>();
                _animator.SetBool("isTrigger", true);
                _animator.SetTrigger("OpenClose");
            }
            else
            {
                //Debug.Log("Nie mozesz tu wejsc");

            }
        }
        else if(cardColour == "red")
        {
            if (Input.GetKeyDown(KeyCode.R) && isActive == true && doorAudioSource.isPlaying == false && redCard.redCard == true)
            {
                doorAudioSource.volume = volumeSound;
                doorAudioSource.pitch = pitchSound;
                doorAudioSource.Play();

                //Animator _animator = gameObject.GetComponentInChildren<Animator>();
                _animator.SetBool("isTrigger", true);
                _animator.SetTrigger("OpenClose");
            }
            else
            {
                //Debug.Log("Nie mozesz tu wejsc");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R) && isActive == true && doorAudioSource.isPlaying == false)
            {
                doorAudioSource.volume = volumeSound;
                doorAudioSource.pitch = pitchSound;
                doorAudioSource.Play();

                //Animator _animator = gameObject.GetComponentInChildren<Animator>();
                _animator.SetBool("isTrigger", true);
                _animator.SetTrigger("OpenClose");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
        //if (isActive == true)
        //{
        //    doorsUI.SetActive(true);
        //}
        if (isActive == true && cardColour == "yellow") //yellow ui
        {           
            doorsUIyellow.SetActive(true);

            if (yellowCard.yellowCard == true)
            {
                doorsUI.SetActive(true);
                doorsUIyellow.SetActive(false);
            }
        }
        else if (isActive == true && cardColour == "blue") //blue ui
        {
            doorsUIblue.SetActive(true);

            if (blueCard.blueCard == true)
            {
                doorsUI.SetActive(true);
                doorsUIblue.SetActive(false);
            }
        }
        else if (isActive == true && cardColour == "red") //red ui
        {
            doorsUIred.SetActive(true);

            if (redCard.redCard == true)
            {
                doorsUI.SetActive(true);
                doorsUIred.SetActive(false);
            }
        }
        else //if(isActive == true && cardColour == null)
        {
            doorsUI.SetActive(true);
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (yellowCard.yellowCard == true)
        {
            doorsUI.SetActive(true);
            doorsUIyellow.SetActive(false);
        }

        if (blueCard.blueCard == true)
        {
            doorsUI.SetActive(true);
            doorsUIblue.SetActive(false);
        }

        if (redCard.redCard == true)
        {
            doorsUI.SetActive(true);
            doorsUIred.SetActive(false);
        }
    }
    */

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;

        isActive = false;

        if (isActive == false)
        {
            doorsUI.SetActive(false);
            doorsUIyellow.SetActive(false);
            doorsUIblue.SetActive(false);
            doorsUIred.SetActive(false);
        }
    }



}
