using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputSystem_Actions inputActions = new InputSystem_Actions();

    public static event Action<InputActionMap> actionMapChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ToggleActionMap(inputActions.Player);
    }

    // Update is called once per frame
    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled) return;

        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}
