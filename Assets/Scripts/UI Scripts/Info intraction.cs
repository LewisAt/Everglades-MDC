using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infointraction : MonoBehaviour
{
    [TextArea(15, 20)]
    public string infoTodisplay;
    public Text TextBoxToReveal;
    public GameObject CanvasBase;
    private GameObject player;

    private void Awake()
    {

        CanvasBase.SetActive(false);
        player = Camera.main.gameObject;

    }
    public void enableAll()
    {
        /* enables the base canvas and sets the text box to the string
         * then starts the disable coroutine that will disable the canvas after 15 seconds
         */
        if(CanvasBase.activeSelf)//checks if the canvas is already active we do this at start to avoid the canvas being active at the start of the game
        {
            CanvasBase.SetActive(false);
            return;
        }
        AddItemToChecklist(this.gameObject.tag);
        CanvasBase.SetActive(true);
        TextBoxToReveal.text = infoTodisplay;
        StartCoroutine(Disable());
    }
    private void FixedUpdate()
    {
        if (CanvasBase.activeSelf)
        {
            LockInfoPanel();

        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(60);
        if(CanvasBase.activeSelf)
        {
            CanvasBase.SetActive(false);

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
        if (CanvasBase.activeSelf == false)
        {
            return;
        }


        Quaternion Lookrotation = Quaternion.LookRotation(CanvasBase.transform.position - player.transform.position, Vector3.up);
        CanvasBase.transform.rotation = Lookrotation;
    }

    private void AddItemToChecklist(string itemName)
    {
        Checklist.ReadItem(itemName);
    }

}
