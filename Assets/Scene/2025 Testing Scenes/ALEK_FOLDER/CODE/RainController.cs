using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public Transform player;
    public ParticleSystem rainParticles;
    public ParticleSystem rippleParticles;
    public ParticleSystem splashParticles;

    public AudioSource rainAudio;
    public AudioSource windAudio;

    public Vector3 overheadOffset = new Vector3(0, 8f, 0);
    public float groundYOffset = 0.1f;

    private bool rainActive = false;

    void Start()
    {
        SetRainState(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetRainState(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetRainState(false);
        }

        if (player != null && rainActive)
        {
            transform.position = player.position + overheadOffset;

            PositionGroundParticles(rippleParticles);
            PositionGroundParticles(splashParticles);
        }
    }

    void SetRainState(bool state)
    {
        rainActive = state;

        if (state)
        {
            if (rainParticles != null) rainParticles.Play();
            if (rippleParticles != null) rippleParticles.Play();
            if (splashParticles != null) splashParticles.Play();
            if (rainAudio != null) rainAudio.Play();
            if (windAudio != null) windAudio.Play();
        }
        else
        {
            if (rainParticles != null) rainParticles.Stop();
            if (rippleParticles != null) rippleParticles.Stop();
            if (splashParticles != null) splashParticles.Stop();
            if (rainAudio != null) rainAudio.Stop();
            if (windAudio != null) windAudio.Stop();
        }
    }

    void PositionGroundParticles(ParticleSystem ps)
    {
        RaycastHit hit;
        Vector3 rayStart = player.position + overheadOffset;

        if (Physics.Raycast(rayStart, Vector3.down, out hit, 100f))
        {
            ps.transform.position = hit.point + new Vector3(0, groundYOffset, 0);
        }
    }


    public void TriggerRain(bool enable)
    {
        SetRainState(enable);
    }
}