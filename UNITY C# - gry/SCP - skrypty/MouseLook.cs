using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 400f;
    public Slider mouseSensitivitySlider;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.visible = false; //kursor jest niewidoczny
        Cursor.lockState = CursorLockMode.Locked; //kursor zatrzymuje sie na srodku ekranu
    }


    void Update()
    {
        mouseSensitivity = mouseSensitivitySlider.value;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //zaezpiecznie przed zrobieniem fikolka kamera

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
