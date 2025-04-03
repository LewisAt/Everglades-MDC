//Ian Marshburn
//Script handles hand trashcan transformation
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRLeftHandToggle : MonoBehaviour
{
    //variable declarations
    public GameObject defaultLeftHandObject, trashCanObject;

    //input actions
    private VRControls inputActions;
    private bool isTrashCanActive = false;

    void Awake()
    {
        inputActions = new VRControls();
    }

    private void OnEnable()
    {
        inputActions.InGameControls.LeftHandToggle.performed += ctx => ToggleHandModel();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.InGameControls.LeftHandToggle.performed -= ctx => ToggleHandModel();
        inputActions.Disable();
    }

    private void ToggleHandModel()
    {
        Debug.Log("VR Player toggled left hand!");
        //toggle trashcan flag
        isTrashCanActive = !isTrashCanActive;

        //apply changes
        defaultLeftHandObject.SetActive(!isTrashCanActive);
        trashCanObject.SetActive(isTrashCanActive);
    }
}
