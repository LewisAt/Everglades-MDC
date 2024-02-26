using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GeneralManager : MonoBehaviour
{

    private bool StoreturningOption = false;
    private GameObject Player;
    private GameObject TurnController;
    public static GeneralManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        SceneInitialSetup();
        Debug.Log("general manager has been started and the scene has been setup");        

    }

    private GameObject Turncontroller;
    void findTurnController()
    {
        TurnController = GameObject.Find("XR Player Rig/XR Origin (XR Rig)/Locomotion System/Turn");
        if(TurnController == null)
        {
            Debug.Log("TurnController has not been found");
        }
        else
        {
            Debug.Log("TurnController has been found");
        }
    }
    public void SetTurningOption(bool SmoothTurning)
    {
        StoreturningOption = SmoothTurning;
        Debug.Log("SmoothTurning has been toggled and the value is now: " + StoreturningOption );
        if(TurnController == null)
        {
            findTurnController();
        }
        if (StoreturningOption)
        {
  
            TurnController.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            TurnController.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;

        }
        else
        {
  
            TurnController.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            TurnController.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        }
    }
  
    
    void SceneInitialSetup()
    {
        findTurnController();
        SetTurningOption(StoreturningOption);

    }

    
}
