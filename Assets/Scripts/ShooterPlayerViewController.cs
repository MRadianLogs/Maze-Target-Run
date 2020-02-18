using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayerViewController : MonoBehaviour
{
    [SerializeField]
    private float lookSensitivity = 100f;

    [SerializeField]
    private Transform playerHead = null;
    [SerializeField]
    private Transform playerBody = null;

    private float xAxisRotation = 0f;
    private float yAxisRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        float lookXPos = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime; //The position of the mouse on the x axis.
        float lookYPos = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime; //The position of the mouse on the y axis.

        xAxisRotation -= lookYPos;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f); //Restricts the head movement to straight up and straight down.
        yAxisRotation += lookXPos;

        playerHead.transform.localRotation = Quaternion.Euler(xAxisRotation, yAxisRotation, 0f); //Rotates head.
        playerBody.transform.localRotation = Quaternion.Euler(0f, yAxisRotation, 0f); //Rotates body.
    }

    public void SetMouseSensitivity(float newPlayerMouseSensitivity)
    {
        lookSensitivity = newPlayerMouseSensitivity;
    }
}
