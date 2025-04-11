
using System.Diagnostics;
using UnityEngine;

public class SkyboxFreeControl : MonoBehaviour
{
    [Header("Skybox Domes")]
    public GameObject dome_EarlyDay;
    public GameObject dome_MidDay;
    public GameObject dome_LittleCloudy;
    public GameObject dome_VeryCloudy;
    public GameObject dome_Night;

    [Header("Rain System")]
    public RainController rainController;

    private bool freeControlUnlocked = false;

    // Called from the Night Trigger script to unlock free control
    public void UnlockFreeSkyboxControl()
    {
        freeControlUnlocked = true;
        UnityEngine.Debug.Log("🆓 Skybox free control unlocked!");
    }

    void Update()
    {
        if (!freeControlUnlocked) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) SetSkybox(dome_EarlyDay, false);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetSkybox(dome_MidDay, false);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetSkybox(dome_LittleCloudy, false);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetSkybox(dome_VeryCloudy, true);  // Rain ON
        if (Input.GetKeyDown(KeyCode.Alpha5)) SetSkybox(dome_Night, false);      // Rain OFF
    }

    void SetSkybox(GameObject activeDome, bool activateRain)
    {
        dome_EarlyDay.SetActive(activeDome == dome_EarlyDay);
        dome_MidDay.SetActive(activeDome == dome_MidDay);
        dome_LittleCloudy.SetActive(activeDome == dome_LittleCloudy);
        dome_VeryCloudy.SetActive(activeDome == dome_VeryCloudy);
        dome_Night.SetActive(activeDome == dome_Night);

        if (rainController != null)
        {
            if (activeDome == dome_VeryCloudy && activateRain)
                rainController.TriggerRain(true);
            else
                rainController.TriggerRain(false);
        }
    }
}