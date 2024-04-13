using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TalkingAligator : MonoBehaviour
{
    public AudioSource CurrentaudioSource;
    public AudioSource VideoAudioSource;
    public VideoPlayer videoPlayer;

    public AudioSource Externalsound;
    public AudioClip startingclip;
    public AudioClip Endingclip;
    private float velocity = 0.0f;
    [SerializeField] private GameObject PivotPoint;
    [SerializeField] private GameObject PlayArea;
    [SerializeField] private GameObject VideoScreen;

    void Start()
    {
        float lengthOfStartingClip = startingclip.length;
        float lengthOfVideo = (float)videoPlayer.length;
        float totalWaituntilEndclip = lengthOfStartingClip + lengthOfVideo + 2;
        PlayArea.SetActive(false);
        VideoScreen.SetActive(false);

        Invoke("startingClip", 5);

        Invoke("playVideo", lengthOfStartingClip + 6);

        Invoke("PlayEndingClip", totalWaituntilEndclip + 6);
        
    }
    void FixedUpdate()
    {
        HandleSpeaking();
    }

    void startingClip()
    {
        PlayArea.SetActive(true);
        Externalsound.clip = startingclip;
        CurrentaudioSource = Externalsound;
        Externalsound.Play();
    }

    void playVideo()
    {

        VideoScreen.SetActive(true);
        CurrentaudioSource = VideoAudioSource;
        videoPlayer.Play();
    }
    public void PlayEndingClip()
    {
        Externalsound.clip = Endingclip;
        CurrentaudioSource = Externalsound;
        Externalsound.Play();
        Invoke("LoadGame", Endingclip.length +1);
    }
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
    public void HandleSpeaking()
    {
        float[] dBLevel = new float[2];
        Vector3 currentRotation = PivotPoint.transform.localEulerAngles;

        CurrentaudioSource.GetOutputData(dBLevel, 0);
        float angle = Mathf.Abs((dBLevel[0] + dBLevel[1]) * 10f);
        Mathf.Clamp(angle, 0, 1);
        if (angle < 0.1f)
        {
            angle = 0;
        }
        float ClampedX = Mathf.Clamp(currentRotation.x, -35, 1);  
        float Xangle = Mathf.SmoothDamp(ClampedX,angle * -35f, ref velocity,0.20f);
  

        PivotPoint.transform.localEulerAngles = new Vector3(Xangle,currentRotation.y ,currentRotation.z);
    }

}
