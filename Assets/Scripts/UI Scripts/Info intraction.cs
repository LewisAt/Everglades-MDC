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
    // Start is called before the first frame update
    public void enableAll()
    {
        if(CanvasBase.activeSelf)
        {
            CanvasBase.SetActive(false);
            return;
        }
        CanvasBase.SetActive(true);
        TextBoxToReveal.text = infoTodisplay;
        StartCoroutine(Disable());
    }
    private void FixedUpdate()
    {
        if (CanvasBase.activeSelf)
        {
            RotateTowards();
        }
    }
    void RotateTowards()
    {
        Vector3 Help = Vector3.RotateTowards(transform.position,Camera.main.transform.position,1f,0f);
        this.transform.rotation = Quaternion.LookRotation(Help);
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(15);
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

}
