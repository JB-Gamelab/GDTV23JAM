using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }


    public float GetMovementVectorX() {
        float inputVectorX = playerInputActions.Player.Movement.ReadValue<float>();

        return inputVectorX;
    }

    public bool GetJump() {
        bool jump = false;
        float jumpPress = playerInputActions.Player.Jump.ReadValue<float>();

        if (jumpPress > 0) {
            jump = true;
        } else {
            jump = false;
        }

        return jump;
    }
}
