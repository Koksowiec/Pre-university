using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Blinking blinking;

    private Flashlight flashlight;

    public GameObject Player;

    Transform transform_Player;

    public float f_RotSpeed = 3.0f, f_MoveSpeed = 3.0f;

    public float MobDistanceRun = 4f;

    

    // Use this for initialization
    void Start()
    {

        blinking = GameObject.FindObjectOfType<Blinking>();
        flashlight = GameObject.FindObjectOfType<Flashlight>();

        transform_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float destination = Vector3.Distance(transform.position, Player.transform.position);

        if (destination < MobDistanceRun && blinking.isBlinking == true || destination < MobDistanceRun && flashlight.isOn == false)
        {

            //transform.LookAt(transform_Player);

            //ememy move with player blinking delay
            StartCoroutine(ExecuteAfterTime(.3f));

            

            /*
            try
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, f_MoveSpeed * Time.deltaTime);
            }
            catch
            {
                Debug.Log("nie ruszam sie");
            }
            */

            /* Look at Player*/
            //transform.rotation = Quaternion.Slerp(transform.rotation
            //                                      , Quaternion.LookRotation(tr_Player.position - transform.position)
            //                                      , f_RotSpeed * Time.deltaTime);

            /* Move at Player*/
            //transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        try
        {
            transform.LookAt(transform_Player);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, f_MoveSpeed * Time.deltaTime);
        }
        catch
        {
            Debug.Log("nie ruszam sie");
        }
    }

    //Death
}