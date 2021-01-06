﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastCamera : MonoBehaviour
{
    public float mouseSensivity = 100f;    
    private float xRotation = 0f;
    private float yRotation = 0f;
    //private float mouseX = 0f;
    //private float mouseY = 0f;   
    public Joystick joystick;   
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        SetCameraRot();
    }    

    public void SetCameraRot() 
    {        
        float mouseY = Mathf.Abs(joystick.Vertical) * mouseSensivity * Time.deltaTime*Input.GetAxis("Mouse Y");
        float mouseX = Mathf.Abs(joystick.Horizontal) * mouseSensivity * Time.deltaTime * Input.GetAxis("Mouse X");
        //if (Input.GetAxis("Mouse X") == 0) mouseX = 0;
        //if (Input.GetAxis("Mouse Y") == 0) mouseY = 0;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -25f, 25f);
        yRotation = Mathf.Clamp(yRotation, -18f, 18f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    public void OnPointerDown(Joystick joystick) 
    {
        float mouseY = Mathf.Abs(joystick.Vertical) * mouseSensivity * Time.deltaTime * Input.GetAxis("Mouse Y");
        float mouseX = Mathf.Abs(joystick.Horizontal) * mouseSensivity * Time.deltaTime * Input.GetAxis("Mouse X");       

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -25f, 25f);
        yRotation = Mathf.Clamp(yRotation, -18f, 18f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
