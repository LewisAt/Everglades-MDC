
using UnityEngine;

public class HurricaneTrigger : MonoBehaviour
{
    [Header("Player Reference")]
    public Transform player;

    [Header("Rain System Controller")]
    public RainFollowPlayer rainFollowPlayer; // Drag your RainFollowPlayer script here

    [Header("Skybox Material")]
    public Material skyboxMaterial;
    public string hurricaneBlendProperty = "_HurricaneBlendFactor";

    [Header("Sound Sources")]
    public AudioSource rainSound;
    public AudioSource windSound;

    [Header("Raycast Settings")]
    public float rayDistance = 100f; // How far to raycast
    public LayerMask hurricaneTriggerLayer; // Make sure your empty object is on this layer

    [Header("Hurricane Settings")]
    public float triggerDistance = 30f;      // Starts effect
    public float fullStormDistance = 5f;     // Max intensity
    public float hurricaneDuration = 120f;   // Total time

    private bool hurricaneActive = false;
    private bool hurricaneTimerStarted = false;
    private float hurricaneTimer = 0f;

    void Update()
    {
        Ray ray = new Ray(player.position + Vector3.up * 1.5f, player.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, hurricaneTriggerLayer))
        {
            float distance = Vector3.Distance(player.position, hit.point);

            float t = Mathf.InverseLerp(triggerDistance, fullStormDistance, distance);
            float hurricaneBlend = 1f - t; // 0 far → 1 close

            // Apply to skybox
            if (skyboxMaterial.HasProperty(hurricaneBlendProperty))
            {
                skyboxMaterial.SetFloat(hurricaneBlendProperty, hurricaneBlend);
            }

            // Rain strength
            if (rainFollowPlayer != null)
            {
                rainFollowPlayer.SetRainIntensity(hurricaneBlend);
            }

            // Audio volumes
            if (rainSound != null) rainSound.volume = hurricaneBlend * 0.8f;
            if (windSound != null) windSound.volume = hurricaneBlend * 0.7f;

            // Hurricane fully triggered
            if (hurricaneBlend >= 1f && !hurricaneTimerStarted)
            {
                StartHurricane();
            }
        }

        if (hurricaneTimerStarted)
        {
            hurricaneTimer -= Time.deltaTime;

            // Begin soft fade after 50 seconds
            float fadeStart = hurricaneDuration - 50f;
            if (hurricaneTimer <= fadeStart)
            {
                float fadeProgress = Mathf.InverseLerp(fadeStart, 0f, hurricaneTimer);
                float inverseFade = 1f - fadeProgress;

                if (skyboxMaterial.HasProperty(hurricaneBlendProperty))
                    skyboxMaterial.SetFloat(hurricaneBlendProperty, inverseFade);

                if (rainFollowPlayer != null)
                    rainFollowPlayer.SetRainIntensity(inverseFade);

                if (rainSound != null) rainSound.volume = inverseFade * 0.8f;
                if (windSound != null) windSound.volume = inverseFade * 0.7f;
            }

            if (hurricaneTimer <= 0f)
            {
                EndHurricane();
            }
        }
    }

    void StartHurricane()
    {
        hurricaneTimerStarted = true;
        hurricaneTimer = hurricaneDuration;
        Debug.Log("Hurricane sequence started!");
    }

    void EndHurricane()
    {
        hurricaneTimerStarted = false;
        Debug.Log("Hurricane finished.");

        if (skyboxMaterial.HasProperty(hurricaneBlendProperty))
            skyboxMaterial.SetFloat(hurricaneBlendProperty, 0f);

        if (rainFollowPlayer != null)
            rainFollowPlayer.SetRainIntensity(0f);

        if (rainSound != null) rainSound.volume = 0f;
        if (windSound != null) windSound.volume = 0f;
    }
}

