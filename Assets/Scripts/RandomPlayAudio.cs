using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomClip();
        
    }
    IEnumerator PlayRandomClip()
    {
        while (true)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            float randomWaitTime = Random.Range(5, 15);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }

}
