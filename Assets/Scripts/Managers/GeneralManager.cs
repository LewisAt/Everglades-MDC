using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GeneralManager : MonoBehaviour
{

    private bool Smooturning = false;
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
        SceneInitialSetup();
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetTurningOption(bool SmoothTurning)
    {
        TurnController = GameObject.Find("Turn");
        if (SmoothTurning)
        {
            SmoothTurning = true;
            TurnController.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            TurnController.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;

        }
        else
        {
            SmoothTurning = false;
            TurnController.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            TurnController.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        }
    }
    void SceneInitialSetup()
    {
        SetTurningOption(Smooturning);

    }

    
}
