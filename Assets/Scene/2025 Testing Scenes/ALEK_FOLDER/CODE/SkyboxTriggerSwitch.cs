using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTriggerSwitch : MonoBehaviour
{
    [Header("What to enable/disable when player enters")]
    public GameObject domeToDisable;
    public GameObject domeToEnable;

    [Header("Rain (optional)")]
    public bool activateRain = false;
    public bool deactivateRain = false;
    public RainController rainController; // Drag your RainFollower object here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (domeToDisable != null) domeToDisable.SetActive(false);
            if (domeToEnable != null) domeToEnable.SetActive(true);

            if (rainController != null)
            {
                if (activateRain) rainController.TriggerRain(true);
                if (deactivateRain) rainController.TriggerRain(false);
            }

            // Optional: Disable this trigger so it only activates once
            gameObject.SetActive(false);
        }
    }
}