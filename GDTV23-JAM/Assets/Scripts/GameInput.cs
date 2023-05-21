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

    public bool GetPrimary() {
        bool primary = false;
        float primaryPress = playerInputActions.Player.Primary.ReadValue<float>();

        if (primaryPress > 0) {
            primary = true;
        } else {
            primary = false;
        }

        return primary;
    }

    public bool GetSecondary() {
        bool secondary = false;
        float secondaryPress = playerInputActions.Player.Secondary.ReadValue<float>();

        if (secondaryPress > 0) {
            secondary = true;
        } else {
            secondary = false;
        }

        return secondary;
    }
}
