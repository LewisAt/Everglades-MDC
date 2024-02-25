using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
//this script will be attached to the base Canvas of the settings panel
public class SettingMenu : MonoBehaviour

{



    /* the below section is pureply deidcated to the base operation
    of the settings tab. With this we track the players
    facing direction lerp it towards them
    this is also the are where disable and enable the 
    panel itself
    */
    GameObject settingMenu;
    private GameObject player;
    public GameObject SettingsOffset;// this will normally be located on the XR RIGCamera;
    private void LockSettingsPanel()
    {
        Vector3 SettingspanelPosition = Vector3.Lerp
        (settingMenu.transform.position, 
        SettingsOffset.transform.position,1f * Time.deltaTime);

        settingMenu.transform.position = SettingspanelPosition;

        Quaternion Lookrotation = Quaternion.LookRotation(settingMenu.transform.position - player.transform.position,Vector3.up);
        settingMenu.transform.rotation =  Lookrotation;
    }


    public void OpenSettingMenu()
    {
        settingMenu.SetActive(true);
    }   
    public void CloseSettingMenu()
    {
        settingMenu.SetActive(false);
    }
    private bool SmoothTurning = false;
    public void SmoothTurningOptions()
    {
        Debug.Log("SmoothTurning has been toggled and the value is now: " + SmoothTurning );
        SmoothTurning = !SmoothTurning;
        GeneralManager.instance.SetTurningOption(SmoothTurning);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        settingMenu = gameObject.transform.GetChild(0).gameObject;
        settingMenu.SetActive(false);
        
    }
    void FixedUpdate()
    {
        LockSettingsPanel();
    }
}
