using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlekTriggerAudio : MonoBehaviour
{
    [Header("Assign the audio source in Inspector")]
    public AudioSource audioToPlay;

    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " collided! Has tag" + other.tag);
        if (!hasPlayed && other.CompareTag("Player"))
        {
            hasPlayed = true;
            audioToPlay.Play();
            Destroy(gameObject, audioToPlay.clip.length);
        }
    }
}