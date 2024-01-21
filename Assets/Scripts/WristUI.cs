using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour
{
    public InputActionAsset inputActions;

    private Canvas handMenu;
    private InputAction menu;

    private void Start()
    {
        handMenu = GetComponent<Canvas>();
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menu.Enable();
        menu.performed += ToggleMenu;
    }

    private void OnDestroy()
    {
        menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        handMenu.enabled = !handMenu.enabled;
    }

}
