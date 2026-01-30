using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector3 rayDist;
    
    private Camera _mainCamera = Camera.main;

    private RaycastHit _hit;
    private Ray _ray;
    private IInteractable _interactable;
    
    private readonly InputAction _lookAction = InputManager.inputActions.Player.Look; 
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
        
        if(RayCastFromCamera())
        {
            print(_hit);
        }
    }

    private bool RayCastFromCamera()
    {
        _ray = _mainCamera.ScreenPointToRay(_lookAction.ReadValue<Vector2>());
        return (Physics.Raycast(_ray,out _hit, 100f));
    }
    
}
