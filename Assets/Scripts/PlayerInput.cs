using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private RaycastHit _hit;
    private Ray _ray;
    private IInteractable _interactable;

    private InputAction _lookAction;

    private Camera _mainCamera;
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
        _mainCamera  = Camera.main;
       _lookAction = InputManager.inputActions.Player.Look; 
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
        if(RayCastFromCamera() && _hit.collider.TryGetComponent(out _interactable))
        {
            print("Clicked");
            _interactable.Interact(gameObject);
        }

    }

    private bool RayCastFromCamera()
    {
        return (Physics.Raycast(_mainCamera.ScreenPointToRay(Mouse.current.position.value), out _hit, 100f));
    }
    
}
