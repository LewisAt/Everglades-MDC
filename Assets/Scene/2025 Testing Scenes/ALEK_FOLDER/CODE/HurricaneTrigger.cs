using System.Collections; // ✅ Required for IEnumerator
using UnityEngine;

public class HurricaneTrigger : MonoBehaviour
{

    [Header("🎯 Player Tag Trigger")]
    public string playerTag = "Player";

    [Header("🌤 Skybox Settings")]
    public Material skyboxMaterial;
    public float hurricaneDuration = 210f; // 3:30 mins
    public float fadeOutTime = 45f; // Last 45s fades out
    public float hurricaneBlendStart = 1f;
    public float hurricaneBlendEnd = 0f;

    [Header("🌧 Particle Effects")]
    public ParticleSystem rainParticles;
    public ParticleSystem rippleParticles;
    public ParticleSystem splashParticles;

    [Header("🎧 Audio Sources")]
    public AudioSource rainAudio;
    public AudioSource windAudio;
    public float maxRainVolume = 1f;
    public float maxWindVolume = 0.8f;

    private bool hurricaneActive = false;

    void OnTriggerEnter(Collider other)
    {
        // ✅ Trigger only once by player
        if (hurricaneActive) return;

        if (other.CompareTag(playerTag))
        {
            StartCoroutine(StartHurricane());
        }
    }

    IEnumerator StartHurricane()
    {
        hurricaneActive = true;

        // 🌩 Set skybox storm mode
        if (skyboxMaterial != null)
            skyboxMaterial.SetFloat("_HurricaneBlendFactor", hurricaneBlendStart);

        // 🎧 Start storm audio
        if (rainAudio != null) rainAudio.volume = maxRainVolume;
        if (windAudio != null) windAudio.volume = maxWindVolume;
        if (rainAudio != null) rainAudio.Play();
        if (windAudio != null) windAudio.Play();

        // 🌧 Start storm particles
        if (rainParticles != null) rainParticles.Play();
        if (rippleParticles != null) rippleParticles.Play();
        if (splashParticles != null) splashParticles.Play();

        // 🕒 Wait for hurricane duration minus fade time
        float waitTime = hurricaneDuration - fadeOutTime;
        yield return new WaitForSeconds(waitTime);

        // ⏳ Start fading out everything
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            float t = elapsedTime / fadeOutTime;

            // 🌤 Blend storm skybox back to clear
            float hurricaneBlend = Mathf.Lerp(hurricaneBlendStart, hurricaneBlendEnd, t);
            if (skyboxMaterial != null)
                skyboxMaterial.SetFloat("_HurricaneBlendFactor", hurricaneBlend);

            // 🎧 Fade audio down
            if (rainAudio != null)
                rainAudio.volume = Mathf.Lerp(maxRainVolume, 0f, t);
            if (windAudio != null)
                windAudio.volume = Mathf.Lerp(maxWindVolume, 0f, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ❌ Stop sounds and effects
        if (rainAudio != null) rainAudio.Stop();
        if (windAudio != null) windAudio.Stop();

        if (rainParticles != null) rainParticles.Stop();
        if (rippleParticles != null) rippleParticles.Stop();
        if (splashParticles != null) splashParticles.Stop();

        // 🌤 Ensure sky is back to normal
        if (skyboxMaterial != null)
            skyboxMaterial.SetFloat("_HurricaneBlendFactor", hurricaneBlendEnd);
    }
}