using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script can be placed on a player to allow the player to move their head 
 * and body separately. This occurs when the head is turned passed a certain buffer. 
 * This will cause the body to rotate.
 * 
 * Note: This may not be the desired script for shooters!
 */
public class PlayerViewController : MonoBehaviour
{
    private float lookSensitivity = 100f;

    [SerializeField]
    private Transform playerHead = null;
    [SerializeField]
    private Transform playerBody = null;

    private float xAxisRotation = 0f;
    private float yAxisRotation = 0f;

    private float turnBuffer = 60f;
    private float rotateSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
        UpdateBodyFacingDirection();
    }

    private void UpdateCameraPosition()
    {
        float lookXPos = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime; //The position of the mouse on the x axis.
        float lookYPos = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime; //The position of the mouse on the y axis.

        xAxisRotation -= lookYPos;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f); //Restricts the head movement to straight up and straight down.
        yAxisRotation += lookXPos;

        playerHead.transform.localRotation = Quaternion.Euler(xAxisRotation, yAxisRotation, 0f);
    }

    private void UpdateBodyFacingDirection()
    {
        if(Vector3.Angle(playerBody.forward, new Vector3(playerHead.transform.forward.x, 0, playerHead.transform.forward.z)) > turnBuffer) 
        {
            //Debug.Log("Need to rotate!");
            float singleStep = rotateSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(playerBody.forward, new Vector3(playerHead.transform.forward.x, 0, playerHead.transform.forward.z), singleStep, 0.0f);
            playerBody.transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
            
        }
        //else
        //{
        //    Debug.Log("Good");
        //}
    }
}
