using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infointraction : MonoBehaviour
{
    [TextArea(15, 20)]
    public string infoTodisplay;
    public Text textBoxToReveal;
    public GameObject canvasBase;
    public AudioSource interactAudio;
    //controls how high the info canvas appears above a given object. Assign in the inspector.
    public float canvasPopupHeight = 5f; 

    private GameObject canvasParent;
    private Vector3 initalPositionInsideOfParent;
    private Vector3 worldPosition;  
    private GameObject player;

    //Added this static to store the most recent instance of interaction dialogue
    static GameObject thereCanOnlyBeOne; 

    private void Awake()
    {
        canvasParent = canvasBase.transform.parent.gameObject;
        initalPositionInsideOfParent = canvasBase.transform.localPosition;
        worldPosition = canvasBase.transform.position;
        canvasBase.SetActive(false);
        player = Camera.main.gameObject;

    }
    public void enableAll(AudioSource thisAudio = null)
    {
        if (thisAudio == null)
        {
            thisAudio = interactAudio;
        }
        //NOTE: You MUST have a GamePlayDialog object in the scene or else the entire method will stall here
        FindObjectOfType<GamePlayDialog>().GetInteractAudio(thisAudio);

        /* enables the base canvas and sets the text box to the string
         * then starts the disable coroutine that will disable the canvas after 15 seconds
         */
        if(canvasBase.activeSelf)//checks if the canvas is already active we do this at start to avoid the canvas being active at the start of the game
        {//This also allows player to toggle off an interaction dialogue by interacting again
            canvasBase.SetActive(false);
            canvasBase.transform.parent = canvasParent.transform;
            canvasBase.transform.localPosition = initalPositionInsideOfParent;
            return;
        }
        if (thereCanOnlyBeOne != null)
        {//this turns off the dialogue of the previous interaction when a new interaction is made
            thereCanOnlyBeOne.SetActive(false);
            thereCanOnlyBeOne.transform.parent = thereCanOnlyBeOne.transform.parent.gameObject.transform;
            thereCanOnlyBeOne.transform.localPosition = thereCanOnlyBeOne.transform.localPosition;
        }
        //assign the new interaction
        thereCanOnlyBeOne = thisAudio.gameObject;

        //unparent the canvas and set its dynamic height
        canvasBase.transform.parent = null;
        canvasBase.transform.position = canvasParent.transform.position + new Vector3(0,canvasPopupHeight,0);

        AddItemToChecklist(this.gameObject.tag);
        canvasBase.SetActive(true);
        textBoxToReveal.text = infoTodisplay;
        StartCoroutine(Disable());
    }
    private void FixedUpdate()
    {
        if (canvasBase.activeSelf)
        {
            LockInfoPanel();

        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(60);
        if(canvasBase.activeSelf)
        {
            canvasBase.SetActive(false);
            canvasBase.transform.parent = canvasParent.transform;
            canvasBase.transform.localPosition = initalPositionInsideOfParent;
        }
    }
    private void LockInfoPanel()
    {
        /*
        this function will lock the Info panel to the players view
        it lerps the settings panel to the players view
        it also keeps the settings panel facing the player
        and lastly it will keep the settings panel at a fixed distance from the playe
        */
        if (canvasBase.activeSelf == false)
        {
            return;
        }


        Quaternion Lookrotation = Quaternion.LookRotation(canvasBase.transform.position - player.transform.position, Vector3.up);
        canvasBase.transform.rotation = Lookrotation;
    }

    private void AddItemToChecklist(string itemName)
    {
        Checklist.ReadItem(itemName);
    }

}
