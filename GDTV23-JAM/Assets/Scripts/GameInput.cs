using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPrimaryPressed;
    public event EventHandler OnSecondaryPressed;
    public event EventHandler OnJumpPressed;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Primary.performed += Primary_performed;
        playerInputActions.Player.Secondary.performed += Secondary_performed;
        playerInputActions.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext context) {
        if (context.performed) {
            OnJumpPressed?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Secondary_performed(InputAction.CallbackContext context) {
        if (context.performed) {
            OnSecondaryPressed?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Primary_performed(InputAction.CallbackContext context) {
        if (context.performed) {
            OnPrimaryPressed?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetMovementVectorX() {
        float inputVectorX = playerInputActions.Player.Movement.ReadValue<float>();

        return inputVectorX;
    }

}
