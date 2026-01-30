using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Camera _mainCamera;

    private RaycastHit _hit;
    private Ray _ray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        InputManager.inputActions.Player.Interact.performed += ClickObject;
    }

    private void OnDisable()
    {
        InputManager.inputActions.Player.Interact.performed -= ClickObject;
    }

    void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    void Start()
    {
        InputManager.ToggleActionMap(InputManager.inputActions.Player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClickObject(InputAction.CallbackContext ctx)
    {
        RayCastFromCamera();
    }

    private bool RayCastFromCamera()
    {
        _ray = _mainCamera.ScreenPointToRay(InputManager.inputActions.Player.Look.ReadValue<Vector2>());
        return (Physics.Raycast(_ray, out _hit));
    }
    
}
