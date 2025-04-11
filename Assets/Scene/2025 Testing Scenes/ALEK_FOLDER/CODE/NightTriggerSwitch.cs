using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NightTriggerSwitch : MonoBehaviour
{
    [Header("Skybox Domes")]
    public GameObject domeToDisable;    // Dome_VeryCloudy
    public GameObject domeToEnable;     // Dome_Night

    [Header("Rain System")]
    public RainController rainController;

    [Header("Skybox Free Control")]
    public SkyboxFreeControl freeControlScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (domeToDisable != null) domeToDisable.SetActive(false);
            if (domeToEnable != null) domeToEnable.SetActive(true);

            if (rainController != null)
                rainController.TriggerRain(false); // Turn off rain

            if (freeControlScript != null)
            {
                freeControlScript.UnlockFreeSkyboxControl();
                UnityEngine.Debug.Log("Night trigger activated — free control now enabled!");
            }

            gameObject.SetActive(false);
        }
    }
}