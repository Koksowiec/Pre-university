using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float runSpeed = 8f;
    public float gravity = -9.81f;

    //public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool isRunning = false;
    public AudioSource backgroundSound;
    public AudioSource deathJumpScare;

    public GameObject blinkingUI;

    public Transform enemyHead;

    //better death
    GameObject startLookAt;
    GameObject endLookAt;
    private HeadBobbing headBobbing;
    private MouseLook mouseLook;
    float waitTime = 3f;
    public GameObject flashlight;
    public GameObject playerUI;

    public CameraShake cameraShakeScript;

    private void Start()
    {
        headBobbing = GameObject.FindObjectOfType<HeadBobbing>();
        mouseLook = GameObject.FindObjectOfType<MouseLook>();
        cameraShakeScript = GameObject.FindObjectOfType<CameraShake>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //jumping
        /*
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        */

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") && isGrounded)
        {
            speed = runSpeed;
            isRunning = true;
        }
        else
        {
            speed = runSpeed/2;
            isRunning = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        startLookAt = GameObject.FindGameObjectWithTag("Start");
        endLookAt = GameObject.FindGameObjectWithTag("End");
    }

    //Death

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && deathJumpScare.isPlaying == false)
        {
            //transform.LookAt(enemyHead);

            backgroundSound.Stop();

            deathJumpScare.volume = 2f;
            deathJumpScare.pitch = 1f;
            deathJumpScare.Play();

            Debug.Log("You Die TRIGGERED playerscript");

            DeathCamera();

            /*
            blinkingUI.SetActive(false);
            FindObjectOfType<DeathMenu>().DeathPause();
            */
        }
    }

    void DeathCamera()
    {
        Transform target = Camera.main.transform; //nowy transform kamery
        target.transform.parent = startLookAt.transform;//przydielamy kamere do nowego obiektu (jako child)
        target.localPosition = Vector3.zero; //resetujemy transform.position kamry

        target.LookAt(endLookAt.transform);

        headBobbing.enabled = false; //wylaczamy head bobbing
        mouseLook.enabled = false; //wylaczamy poruszanie myszka

        startLookAt.GetComponent<Light>().enabled = true; //wlaczamy swiatlo obiektu start aby oswietlic enemy

        Destroy(flashlight);

        blinkingUI.SetActive(false);
        playerUI.SetActive(false);

        StartCoroutine(WaitForDeath());
    }

    IEnumerator WaitForDeath()
    {
        cameraShakeScript.enabled = true;
        yield return new WaitForSeconds(waitTime);
        cameraShakeScript.enabled = false;
        FindObjectOfType<DeathMenu>().DeathPause();
    }
}
