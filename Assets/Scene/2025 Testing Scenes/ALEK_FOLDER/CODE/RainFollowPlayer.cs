
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    [Header("Player Reference")]
    public Transform player;

    [Header("Rain Particle Systems")]
    public ParticleSystem rainSystem;        // Main falling rain
    public ParticleSystem rippleSystem;      // Ripples on ground
    public ParticleSystem splashSystem;      // Splashes on impact

    [Header("Offset Settings")]
    public Vector3 offset = new Vector3(0, 4f, 0); // Offset above player head

    void Start()
    {
        if (rainSystem == null) rainSystem = GetComponent<ParticleSystem>();
        rainSystem.Stop();

        // Stop ripple and splash too
        if (rippleSystem != null) rippleSystem.Stop();
        if (splashSystem != null) splashSystem.Stop();
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }

    /// <summary>
    /// Controls rain, ripple, and splash intensity (0 = off, 1 = heavy)
    /// </summary>
    public void SetRainIntensity(float intensity)
    {
        intensity = Mathf.Clamp01(intensity);

        // Main Rain
        if (rainSystem != null)
        {
            var mainEmission = rainSystem.emission;
            mainEmission.rateOverTime = intensity * 100f;

            if (intensity > 0f && !rainSystem.isPlaying)
                rainSystem.Play();
            else if (intensity == 0f && rainSystem.isPlaying)
                rainSystem.Stop();
        }

        // Ripple
        if (rippleSystem != null)
        {
            var rippleEmission = rippleSystem.emission;
            rippleEmission.rateOverTime = intensity * 50f;

            if (intensity > 0f && !rippleSystem.isPlaying)
                rippleSystem.Play();
            else if (intensity == 0f && rippleSystem.isPlaying)
                rippleSystem.Stop();
        }

        // Splash
        if (splashSystem != null)
        {
            var splashEmission = splashSystem.emission;
            splashEmission.rateOverTime = intensity * 30f;

            if (intensity > 0f && !splashSystem.isPlaying)
                splashSystem.Play();
            else if (intensity == 0f && splashSystem.isPlaying)
                splashSystem.Stop();
        }
    }
}