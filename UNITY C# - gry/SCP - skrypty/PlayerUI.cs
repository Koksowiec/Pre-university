using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text batteryLevel;
    private Flashlight flashlight;

    //public Text blinkingLevel;
    public float blinkingLevel;
    private Blinking blinking;
    public GameObject blinkingImage1, blinkingImage2, blinkingImage3, blinkingImage4, blinkingImage5, blinkingImage6, blinkingImage7, blinkingImage8, blinkingImage9, blinkingImage10;

    // Start is called before the first frame update
    void Start()
    {
        //batteryLevel = GetComponentInChildren<Text>();
        flashlight = GameObject.FindObjectOfType<Flashlight>();
        blinking = GameObject.FindObjectOfType<Blinking>();

        batteryLevel.text = "BATTERY: " + flashlight.batLevel.ToString();
        //blinkingLevel.text = "Blinking" + blinking.timer.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {

        batteryLevel.text = "BATTERY: " + flashlight.batLevel.ToString();

        //blinkingLevel.text = "Blinking: " + blinking.timer.ToString();

        blinkingLevel = blinking.timer;

        if (blinkingLevel >= 9.5)
        {
            blinkingImage10.SetActive(true);
            blinkingImage9.SetActive(true);
            blinkingImage8.SetActive(true);
            blinkingImage7.SetActive(true);
            blinkingImage6.SetActive(true);
            blinkingImage5.SetActive(true);
            blinkingImage4.SetActive(true);
            blinkingImage3.SetActive(true);
            blinkingImage2.SetActive(true);
            blinkingImage1.SetActive(true);
        }
        else if (blinkingLevel < 10 && blinkingLevel >= 9)
        {
            blinkingImage10.SetActive(false);
        }
        else if (blinkingLevel < 9 && blinkingLevel >= 8)
        {
            blinkingImage9.SetActive(false);
        }
        else if (blinkingLevel < 8 && blinkingLevel >= 7)
        {
            blinkingImage8.SetActive(false);
        }
        else if (blinkingLevel < 7 && blinkingLevel >= 6)
        {
            blinkingImage7.SetActive(false);
        }
        else if (blinkingLevel < 6 && blinkingLevel >= 5)
        {
            blinkingImage6.SetActive(false);
        }
        else if (blinkingLevel < 5 && blinkingLevel >= 4)
        {
            blinkingImage5.SetActive(false);
        }
        else if (blinkingLevel < 4 && blinkingLevel >= 3)
        {
            blinkingImage4.SetActive(false);
        }
        else if (blinkingLevel < 3 && blinkingLevel >= 2)
        {
            blinkingImage3.SetActive(false);
        }
        else if (blinkingLevel < 2 && blinkingLevel >= 1)
        {
            blinkingImage2.SetActive(false);
        }
        else if (blinkingLevel < 1 && blinkingLevel >= 0)
        {
            blinkingImage1.SetActive(false);
        }
    }

}
