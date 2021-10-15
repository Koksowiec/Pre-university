using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour
{

    public float a = 2.55f;
    public float b = 124.98f;
    public float c = 3.78f;
    public float d = 16.1f;

    public GameObject pickUpUi;
    public string textShown = "Press 'E' to pickup";
    private bool showText;
    public int Bat;

    public GameObject Flight;
    public int mainBat;

    [HideInInspector] public bool safeRemove;

    public AudioSource objectPickUpSound;
    public float volumeSound = 1f;
    public float pitchSound = 1f;

    public Transform battery_MainTransform;

    public GameObject batteryObject;

    void Start()
    {
        showText = false;
    }

    void Update()
    {
        
        if (showText == true)
        {
            pickUpUi.SetActive(true);
        }
        else
        {
            pickUpUi.SetActive(false);
        }
        

        //if (!safeRemove)
        //{
        if (Input.GetKeyDown(KeyCode.E) && showText == true)
        {
            //Dzwiek
            objectPickUpSound.volume = volumeSound;
            objectPickUpSound.pitch = pitchSound;
            objectPickUpSound.Play();

            mainBat = Flight.GetComponent<Flashlight>().batLevel;
            Bat = 20;
            Flight.GetComponent<Flashlight>().batLevel = Bat += mainBat;
            safeRemove = true;
            
            if (safeRemove)
            {         
                pickUpUi.SetActive(false);

                //Destroy children poniewaz usuniecie tego obiektu skutkowalo brakiem dzwieku
                foreach (Transform child in battery_MainTransform.transform)
                {
                   GameObject.Destroy(child.gameObject);
                }

                //bez tego mozna klikac miejsce baterii i nabijac sobie jej ilosc
                //batteryObject.SetActive(false);
                
            }

            batteryObject.SetActive(false);
        }
        //} 

    }


    void OnTriggerEnter(Collider other)
    {
        showText = true;

        /*
        if (!safeRemove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                mainBat = Flight.GetComponent<Flashlight>().batLevel;
                Bat = 20;
                Flight.GetComponent<Flashlight>().batLevel = Bat += mainBat;
                safeRemove = true;

                if (safeRemove)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        */
    }

    void OnTriggerExit(Collider other)
    {
        showText = false;
    }

    //void OnGUI()
    //{
    //   if (showText)
    //    {
    //        GUI.Box(new Rect(Screen.width / a, Screen.height / b, Screen.width / c, Screen.height / d), textShown);
    //    }
    //}

}