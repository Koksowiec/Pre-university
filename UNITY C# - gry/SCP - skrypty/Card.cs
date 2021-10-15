using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    bool isTrigger = false;
    bool safeRemove;
    public Transform card_MainTransform;
    public GameObject cardMainObject;

    public string cardColour;

    [HideInInspector] public bool yellowCard = false;
    [HideInInspector] public bool blueCard = false;
    [HideInInspector] public bool redCard = false;

    //ui
    public GameObject yellowCardObject;
    public GameObject blueCardObject;
    public GameObject redCardObject;
    public GameObject pickUpUi;

    //sound
    public AudioSource objectPickUpSound;
    public float volumeSound = 1f;
    public float pitchSound = 1f;




    // Start is called before the first frame update
    void Start()
    {
        //pickUpUi = GameObject.Find("PickUp - yellowCard");
    }

    // Update is called once per frame
    void Update()
    {
        //ui
        if (isTrigger == true)
        {
            pickUpUi.SetActive(true);
        }
        else
        {
            pickUpUi.SetActive(false);
        }

        //card yellow -> blue -> red
        if (Input.GetKeyDown(KeyCode.E) && isTrigger == true && cardColour == "yellow" && objectPickUpSound.isPlaying == false)
        {
            yellowCard = true;

            yellowCardObject.SetActive(true);

            //Dzwiek
            objectPickUpSound.volume = volumeSound;
            objectPickUpSound.pitch = pitchSound;
            objectPickUpSound.Play();

            safeRemove = true;

            if (safeRemove)
            {
                pickUpUi.SetActive(false);

                //Destroy children poniewaz usuniecie tego obiektu skutkowalo brakiem dzwieku

                foreach (Transform child in card_MainTransform.transform)
                {
                    Debug.Log("yellow "+yellowCard);
                    GameObject.Destroy(child.gameObject);
                }

                cardMainObject.SetActive(false);

                //Destroy(this.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isTrigger == true && cardColour == "blue" && objectPickUpSound.isPlaying == false)
        {
            blueCard = true;

            blueCardObject.SetActive(true);

            //Dzwiek
            objectPickUpSound.volume = volumeSound;
            objectPickUpSound.pitch = pitchSound;
            objectPickUpSound.Play();

            safeRemove = true;

            if (safeRemove)
            {
                pickUpUi.SetActive(false);

                //Destroy children poniewaz usuniecie tego obiektu skutkowalo brakiem dzwieku

                foreach (Transform child in card_MainTransform.transform)
                {
                    Debug.Log("blue "+blueCard);
                    GameObject.Destroy(child.gameObject);
                }

                cardMainObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isTrigger == true && cardColour == "red" && objectPickUpSound.isPlaying == false)
        {
            redCard = true;

            redCardObject.SetActive(true);

            //Dzwiek
            objectPickUpSound.volume = volumeSound;
            objectPickUpSound.pitch = pitchSound;
            objectPickUpSound.Play();
            
            safeRemove = true;

            if (safeRemove)
            {
                pickUpUi.SetActive(false);

                //Destroy children poniewaz usuniecie tego obiektu skutkowalo brakiem dzwieku

                foreach (Transform child in card_MainTransform.transform)
                {
                    Debug.Log("yellow " + redCard);
                    GameObject.Destroy(child.gameObject);
                }

                cardMainObject.SetActive(false);

                //Destroy(this.gameObject);
            }
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
