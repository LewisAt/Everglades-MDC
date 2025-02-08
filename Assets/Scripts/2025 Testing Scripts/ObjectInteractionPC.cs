//Ian Marshburn
//Script is used to trigger the interactable object script equivalent to what the VR select button does.
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteractionPC : MonoBehaviour
{

    private PCControls inputActions;

    private void Awake()
    {
        inputActions = new PCControls();
    }

    private void OnEnable()
    {
        inputActions.InGameControls.Interact.performed += OnClick;
        inputActions.InGameControls.Enable();
    }
    private void OnDisable()
    {
        inputActions.InGameControls.Interact.performed -= OnClick;
        inputActions.InGameControls.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {//this should do everything that the VR version does when interacting
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red, 3f);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20f))
        {
            Debug.Log("RaycastTest");
            if (hit.collider.gameObject.TryGetComponent(out Infointraction interaction))
            {
                Debug.Log("PC player clicked " + interaction.name);

                //enable infographic panel
                interaction.enableAll();

                AudioSource audio = interaction.interactAudio;
                if (audio != null)
                {//play info audio
                    Debug.Log("AudioSource found!");
                    audio.Play();
                }
                Debug.Log("PC interact success!");
            }
        }
    }
}
