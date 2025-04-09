//Ian Marshburn
//Script is used to trigger the interactable object script equivalent to what the VR select button does.
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteractionPC : MonoBehaviour
{

    private PCControls inputActions;
    public Transform grabPoint;
    [HideInInspector]
    public GameObject trashObject;
    [HideInInspector]
    public bool hasTrash = false;

    private void Awake()
    {
        inputActions = new PCControls();
    }

    private void OnEnable()
    {
        inputActions.InGameControls.Interact.performed += OnClick;
        inputActions.InGameControls.Enable();
        inputActions.InGameControls.Pause.performed += OnPauseInput;
        inputActions.InGameControls.Enable();
    }

    private void OnDisable()
    {
        inputActions.InGameControls.Interact.performed -= OnClick;
        inputActions.InGameControls.Disable();
        inputActions.InGameControls.Pause.performed -= OnPauseInput;
        inputActions.InGameControls.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {//this should do everything that the VR version does when interacting
        if ((hasTrash || trashObject != null) && Time.timeScale != 0)
        {
            trashObject.transform.parent = null;
            trashObject.GetComponent<Rigidbody>().isKinematic = false;

            trashObject = null;
            hasTrash = false;
        }
        else
        {
            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red, 3f);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20f))
            {
                Debug.Log("RaycastTest");
                if (hit.collider.gameObject.TryGetComponent(out Infointraction interaction) && Time.timeScale != 0)
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

                    //Add interacted item to checklist
                    GameDataManager.Instance.FillChecklist(interaction.tag);
                }
                //lowercase T "trash" is used for the small interactive trash objects
                else if (hit.collider.tag == "trash")
                {
                    trashObject = hit.collider.gameObject;
                    trashObject.transform.parent = grabPoint;
                    trashObject.transform.localPosition = Vector3.zero;
                    trashObject.transform.localRotation = grabPoint.localRotation;

                    trashObject.GetComponent<Rigidbody>().isKinematic = true;

                    hasTrash = true;
                }
            }
        }
    }

    //pause input
    private void OnPauseInput(InputAction.CallbackContext context)
    {
        IanUIController.Instance.PauseMenuToggle();
    }
}
