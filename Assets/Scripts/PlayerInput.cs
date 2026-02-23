using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private Transform playerHead;

    private IInteractable _interactable;
    private RaycastHit _hit;

    private void OnEnable()
    {
        InputManager.InputActions.Player.Interact.performed += ClickObject;
    }

    private void OnDisable()
    {
        InputManager.InputActions.Player.Interact.performed -= ClickObject;
    }

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineCamera>();
        }

        if (playerHead == null)
        {
            playerHead = GameObject.FindGameObjectWithTag("PlayerHead").transform;
        }
    }

    private void Start()
    {
        InputManager.ToggleActionMap(InputManager.InputActions.Player);
    }

    private void ClickObject(InputAction.CallbackContext context)
    {
        if (RayCastFromCamera())
        {
            _interactable.Interact();
        }
    }

    private bool RayCastFromCamera()
    {
        print("Click");
        return Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward * 10, out _hit) &&
               _hit.collider.TryGetComponent(out _interactable);
    }
}