
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    [Header("🧍‍♂️ Player Reference")]
    public Transform player; // Assign your FirstPersonPCPlayer here

    [Header("☔ Rain Effects")]
    public ParticleSystem rainParticles;
    public ParticleSystem rippleParticles;
    public ParticleSystem splashParticles;

    [Header("🎧 Rain & Wind Audio")]
    public AudioSource rainAudio;
    public AudioSource windAudio;

    [Header("📍 Follow Settings")]
    public Vector3 rainOffset = new Vector3(0, 5f, 0); // Adjust height above player
    public bool onlyFollowWhenRaining = true;

    private bool isRaining = false;

    void Update()
    {
        // 🎮 Trigger Rain with Key 8
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartRainEffect();
        }

        // ☀️ Stop Rain with Key 9
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            StopRainEffect();
        }

        // 🧍‍♂️ Always follow player
        if (player != null && (!onlyFollowWhenRaining || isRaining))
        {
            transform.position = player.position + rainOffset;
        }
    }

    void StartRainEffect()
    {
        if (isRaining) return;

        // 🌧 Start all rain effects
        if (rainParticles != null) rainParticles.Play();
        if (rippleParticles != null) rippleParticles.Play();
        if (splashParticles != null) splashParticles.Play();

        // 🔊 Enable audio
        if (rainAudio != null) rainAudio.Play();
        if (windAudio != null) windAudio.Play();

        isRaining = true;
    }

    void StopRainEffect()
    {
        if (!isRaining) return;

        // ❌ Stop all rain effects
        if (rainParticles != null) rainParticles.Stop();
        if (rippleParticles != null) rippleParticles.Stop();
        if (splashParticles != null) splashParticles.Stop();

        // 🔇 Stop audio
        if (rainAudio != null) rainAudio.Stop();
        if (windAudio != null) windAudio.Stop();

        isRaining = false;
    }
}