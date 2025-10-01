using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    PlayerMovement controls;
    PlayerMovement.MovementActions groundMovement;
    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerMovement();
        groundMovement = controls.Movement;
        groundMovement.HorizontalMove.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }
    void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
    }
    private void OnEnable()
    {
        groundMovement.Enable();
    }
    private void OnDisable()
    {
        groundMovement.Disable();
    }
}
