using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{

    public event Action InteractEvent;
    public event Action SelectEvent;

    Controls controls;



    public Vector2 MovementValue { get; private set; }
    public Vector2 mousePos { get; private set; }

    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        InteractEvent?.Invoke();   
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        SelectEvent?.Invoke();

        
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }
}
