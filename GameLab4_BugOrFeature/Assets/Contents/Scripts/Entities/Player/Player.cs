using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] private InputManager inputManager;
    private CharacterController characterController;

    public float moveSpeed = 8f;
    public Camera viewCamera;
    public PlayerController controller;
    public GunController gunController;
    public Gun gun;
    public Projectile projectile;

    public bool isHeadAttached = false;
    public bool areArmsAttached = false;
    public bool isTorsoAttached = false;
    public bool areLegsAttached = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public override void Start()
    {
        base.Start();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }
    private void Update()
    {
        Vector2 movementInput = inputManager.GetMovementInput();
        Vector3 movementDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        movementDirection.Normalize();
        characterController.Move(moveSpeed * Time.deltaTime * movementDirection);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
        while (areArmsAttached == true)
        {
            moveSpeed = 7.5f;
            gun.DifficultShooting();
        }

        if (areLegsAttached == true)
        {
            moveSpeed = 7.5f;
        }
    }
}
