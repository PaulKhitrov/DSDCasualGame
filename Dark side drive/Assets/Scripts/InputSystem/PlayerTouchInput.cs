using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchInput
{
    public event Action ToRight;
    public event Action ToLeft;
    private InputSystem _inputSystem;

    public PlayerTouchInput()
    {
        _inputSystem = new InputSystem();
    }

    public void Enable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.Strafe.performed += TouchScreen;
    }

    public void Disable()
    {
        _inputSystem.Player.Strafe.performed -= TouchScreen;
        _inputSystem.Disable();
    }

    private void TouchScreen(InputAction.CallbackContext action)
    {
        if (action.ReadValue<Vector2>().x < Screen.width / 2)
        {
            ToLeft?.Invoke();
        }
        else if (action.ReadValue<Vector2>().x > Screen.width / 2)
        {
            ToRight?.Invoke();
        }
    }
}