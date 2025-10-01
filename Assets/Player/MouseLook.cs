using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    float MouseX, MouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;
    private void Update()
    {
       transform.Rotate(Vector3.up * MouseX * Time.deltaTime);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetPosition = transform.eulerAngles;
        targetPosition.x = xRotation;
        playerCamera.eulerAngles = targetPosition;
    }

    public void RecieveInput(Vector2 MouseInput)
    {
        MouseX = MouseInput.x * sensitivityX;
        MouseY = MouseInput.y * sensitivityY;
    }
}
