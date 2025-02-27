using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{

    public Transform player;
    public float mouseSensivity;

    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * (mouseSensivity * Time.deltaTime);
        yRotation -= Input.GetAxis("Mouse Y") * (mouseSensivity * Time.deltaTime);

        transform.rotation = Quaternion.Euler(Mathf.Clamp(yRotation, -60, 70), xRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, xRotation, 0);

        
       
        //Debug.Log(Mouse.current.delta.ReadValue().x);
        //Debug.Log(Mouse.current.delta.ReadValue().y);
    }
}
