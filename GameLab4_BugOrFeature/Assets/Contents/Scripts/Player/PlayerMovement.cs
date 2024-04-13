using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float movementSpeed = 5.5f;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Vector2 movementInput = inputManager.GetMovementInput();
        Vector3 movementDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        movementDirection.Normalize();
        controller.Move(movementSpeed * Time.deltaTime * movementDirection);
    }
}
