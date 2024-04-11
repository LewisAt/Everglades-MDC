using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public dialogClip[] dialogClips;

    private float timer = 0.0f;
    int minutes = 0;

    void Update()
    {
        timer += Time.deltaTime;

        minutes = Mathf.FloorToInt(timer / 60F);

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < dialogClips.Length; )
        {
            if (minutes >= dialogClips[i].MomentofPlayByMinuteInPlay && 
            (i == dialogClips.Length - 1 || minutes < dialogClips[i + 1].MomentofPlayByMinuteInPlay))
            {
            audioSource.clip = dialogClips[i].audioClips;
            audioSource.Play();
            }
        }
    
    }

}
public class dialogClip
{
    public AudioClip audioClips;
    public int MomentofPlayByMinuteInPlay;
}
