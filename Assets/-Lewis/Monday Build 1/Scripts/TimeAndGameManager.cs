using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class TimeAndGameManager : MonoBehaviour
{
    [SerializeField ]
    public float GameLength = 12; 
    //An object to hold our sun
    [SerializeField]
    private GameObject Sun; 
    //and object to hold our moon  both of these are pivots
    [SerializeField]
    private GameObject Moon;
    // a list of objects based on the class below. it hold variables that we use to change the skybox material
    // we have we could later just use more skyboxes and have a main one lerp between those
    [SerializeField]
    private SkyLightingInformation[] SkyArrays;// the first one of these should be the first sky of the game at lunch

    //enabled the use of our slider for the time variable rather than elapsed time in game from our timers
    [SerializeField]
    private bool UseSelectedTime = false;
  
    [SerializeField]
    [Range(0, 24)]
    public float timeInRange = 0;

    //this is math done before hand so it does not lag  but 15f represents the number of degrees the sun must move in an hour to do a full 360 after 24 hours
    private float RotationPerHour = 15f;

    //a rotation variable to hold our suns current rotation
    Quaternion SunsCurrentHourRotation;
    //the current skybox we are manipulating to make change our sky color
    public Material _ourSkybox;


    int hour;
    int Minutes;


    float CurrentTime;
    float timeElapsed;


    float TheCurrentTimeInRotation;
    float HoursInAMinut;

    //on the first frame of the game this acitvates and does some simple math for us before contining to the rest of the code.
    private void Awake()
    {
        HoursInAMinut = 24 / GameLength;
    }

    public void Update()
    {
        Random.ReferenceEquals(CurrentTime, Time.time);
        internalclock();
        GetCurrentSkyInfo();
        Debug.Log("The time is " + CurrentTime);

    }
    private void FixedUpdate()
    {
        //SkyColorTransitioning();

    }


    float SunSize;
    float SunSizeConvergence;
    float AtmosphereThickness;
    Color SkyTint;
    Color GroundTint;
    float Exposure;
    void GetCurrentSkyInfo()
    {
        SunSize = _ourSkybox.GetFloat("_SunSize");
        SunSizeConvergence = _ourSkybox.GetFloat("_SunSizeConvergence");
        AtmosphereThickness = _ourSkybox.GetFloat("_AtmosphereThickness");
        SkyTint = _ourSkybox.GetColor("_SkyTint");
        GroundTint = _ourSkybox.GetColor("_Ground");
        Exposure = _ourSkybox.GetFloat("_Exposure");
        //print(SunSize);
        //print(SunSizeConvergence);
        //print(AtmosphereThickness);
        //print(SkyTint);
        //print(GroundTint);
        //print(Exposure);
    }
    int i = 0;
    int j = 0;
    void SkyColorTransitioning()
    {

        float A_SunSize = SkyArrays[i].Skymaterial.GetFloat("_SunSize");
        float A_SunSizeConvergence = SkyArrays[i].Skymaterial.GetFloat("_SunSizeConvergence");
        float A_AtmosphereThickness = SkyArrays[i].Skymaterial.GetFloat("_AtmosphereThickness");
        Color A_SkyTint = SkyArrays[i].Skymaterial.GetColor("_SkyTint");
        float A_Exposure = SkyArrays[i].Skymaterial.GetFloat("_Exposure");
        float A_Hour = SkyArrays[i].SkyHourPeak;
        j = i + 1;
        if(j == SkyArrays.Length)
        {
            j = 0;
        }
        float B_SunSize = SkyArrays[j].Skymaterial.GetFloat("_SunSize");
        float B_SunSizeConvergence = SkyArrays[j].Skymaterial.GetFloat("_SunSizeConvergence");
        float B_AtmosphereThickness = SkyArrays[j].Skymaterial.GetFloat("_AtmosphereThickness");
        Color B_SkyTint = SkyArrays[j].Skymaterial.GetColor("_SkyTint");
        float B_Exposure = SkyArrays[j].Skymaterial.GetFloat("_Exposure");
        float B_Hour = SkyArrays[j].SkyHourPeak;
        float timeBetweenEvents = B_Hour - A_Hour;
        float t = (CurrentTime - A_Hour) / timeBetweenEvents;

        Debug.Log(B_Hour + " B hour " + A_Hour + " A hour " + timeBetweenEvents + " timeBween these events " + t + " Currentime " + B_SunSize + " B_SunSize " + A_SunSize + " A_SunSize");
        float C_SunSize = Mathf.Lerp(A_SunSize, B_SunSize, t);
        _ourSkybox.SetFloat("_SunSize",C_SunSize);
        if(CurrentTime > B_Hour && j == SkyArrays.Length)
        {
            i = 0;
        }
        else if (CurrentTime > B_Hour)
        {
            i++;
        }

        Debug.Log(" I is " + i + "J is " + j);


    }
    void UpdateSunRotation()
    {
        SunsCurrentHourRotation = Quaternion.Euler(TheCurrentTimeInRotation, 0, 0);

        Quaternion sunPosition = Quaternion.Lerp(Sun.transform.rotation, SunsCurrentHourRotation, 1f);
        Sun.transform.rotation = sunPosition;
    }
   
    void internalclock()
    {
        timeElapsed += Time.deltaTime; // starts counting the number of seconds that pass since the start of the game I think there is one command in unity for this
        Moon.transform.rotation = Sun.transform.rotation;// sets the rotation of the moon pivot to match that of our sun again there might be an easier way by just making the moon
        //a child of the sun
        float currentHour = HoursInAMinut * (timeElapsed / 60f );// converts our seconds
        if(UseSelectedTime)
        {
            CurrentTime = timeInRange;
        }
        else
        {
            CurrentTime = currentHour;
        }
        if (CurrentTime  >= 23.99) 
        {
            timeElapsed = 0;
        }
        TheCurrentTimeInRotation = CurrentTime * RotationPerHour;
        UpdateSunRotation();

    }


    
    private string currentTime()
    {
        string timeString;
        if (CurrentTime <= .99)
        {
            hour = (int)CurrentTime;
            Minutes = (int)(60 * (CurrentTime - hour));

            timeString = string.Format("{1:00}", hour, Minutes);
            timeString = timeString + " AM";
        }
        else if (CurrentTime <= 11.99)
        {
            hour = (int)CurrentTime;
            Minutes = (int)(60 * (CurrentTime - hour));

            timeString = string.Format("0:00:{1:00}", hour, Minutes);
            timeString = timeString + " AM";
        }
        else if(CurrentTime <= 12.99)
        {
            hour = (int)CurrentTime;
            Minutes = (int)(60 * (CurrentTime - hour));
            timeString = string.Format("0:00:{1:00}", hour, Minutes);
            timeString = timeString + " PM";

        }
        else
        {
            hour = (int)CurrentTime;
            Minutes = (int)(60 * (CurrentTime - hour));

            timeString = string.Format("0:00:{1:00}", hour, Minutes);
            timeString = timeString + " PM";

        }
        return timeString;

    }
}

[System.Serializable]
public class SkyLightingInformation
{
    public Material Skymaterial;
    public float SkyHourPeak;
    public HDRColorspace SkyColor;
    public HDRColorspace EquatorColor;
    public HDRColorspace Color;

}
