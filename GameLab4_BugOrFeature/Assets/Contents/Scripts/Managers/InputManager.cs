using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;

    private void Awake()
    {
        playerInput = new PlayerInput();

        // Check if playerInput is null
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component is not found on " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        // Initialize move if playerInput is not null
        if (playerInput != null)
        {
            move = playerInput.Player.Move;
            playerInput.Enable();
        }
        else
        {
            Debug.LogError("PlayerInput is not initialized.");
        }
    }

    public Vector2 GetMovementInput()
    {
        // Check if move is not null before trying to read its value
        if (move != null)
        {
            return move.ReadValue<Vector2>();
        }
        else
        {
            Debug.LogError("Move action is not assigned.");
            return Vector2.zero;
        }
    }
}

