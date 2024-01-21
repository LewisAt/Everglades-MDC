using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UI;
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
    public int huntingBonus;
    public GameObject animalSpawner;
    public GameObject trashSpawner;

    //this is math done before hand so it does not lag  but 15f represents the number of degrees the sun must move in an hour to do a full 360 after 24 hours
    private float RotationPerHour = 15f;

    //a rotation variable to hold our suns current rotation
    Quaternion SunsCurrentHourRotation;
    //the current skybox we are manipulating to make change our sky color
    public Material _ourSkybox;

    public Text TimeLeft;
    public Text NextInvasiveSpawnText;
    public Text NextHuntText;
    public Text NextAnimalText;
    public Text TotalSpawnedText;


    private int animalspawned;

    int hour;
    int Minutes;


    float CurrentTime;
    float timeElapsed;
    float TheCurrentTimeInRotation;
    float HoursInAMinut;
    bool nightMode;
    int dayBonus;
    int nightBonus;
    //public GameObject[] buttons;

    //on the first frame of the game this acitvates and does some simple math for us before contining to the rest of the code.
    private void Awake()
    {
        HoursInAMinut = 24 / GameLength;
    }

    public void Update()
    {
        internalclock();
        //GetCurrentSkyInfo();
        setGameTimeUI();

    }
    float SpawnpreviousValue = 0;
    float SpawncurrentValue = 0;

    float HuntpreviousValue = 0;
    float HuntcurrentValue = 0; 
    
    float InvasivepreviousValue = 0;
    float InvasivecurrentValue = 0;

    private void FixedUpdate()
    {
        SpawnpreviousValue = SpawncurrentValue;
        SpawncurrentValue = timeElapsed % NextAnimalSpawnDelay;
        HuntpreviousValue = HuntcurrentValue;
        HuntcurrentValue = timeElapsed % NextHuntDelay;
        InvasivepreviousValue = InvasivecurrentValue;
        InvasivecurrentValue = timeElapsed % invasiveSpawnDelay;



        /*if (animalSpawner.GetComponent<BasicAnimalSpawner>().animalsSpawned >= animalSpawner.GetComponent<BasicAnimalSpawner>().maxAnimals)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
        }*/
        if (CurrentTime >= 20 && CurrentTime <= 6)
        {
            nightBonus = huntingBonus;
            dayBonus = 0;
        }
        else
        {
            dayBonus = huntingBonus;
            nightBonus = 0;
        }
        //SkyColorTransitioning();
        if (SpawncurrentValue < SpawnpreviousValue)
        {
            animalSpawner.GetComponent<BasicAnimalSpawner>().animalsSpawned = 0;
            Debug.Log("Spawn func was called");

            //SPAWN FISH
            if (GameObject.FindGameObjectsWithTag("Fish").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnFish();
                
            }
            //SPAWN RABBIT
            if (GameObject.FindGameObjectsWithTag("Rabbit").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnRabbit();
              
            }
            //SPAWN FROG
            if (GameObject.FindGameObjectsWithTag("Frog").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnAFrog();

            }
            //SPAWN CROCIDLE 
            if (GameObject.FindGameObjectsWithTag("Aligator").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnAligator();
                
            }
            //SPAWN CAT
            if (GameObject.FindGameObjectsWithTag("Cat").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnCat();
               
            }
            //SPAWN PYTHON
            if (GameObject.FindGameObjectsWithTag("Python").Length != 0)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnPython();
                
            }
        }
        if (HuntcurrentValue < HuntpreviousValue)
        {
            Debug.Log("Hunt func was called");

            //PYTHON HUNTING
            if (GameObject.FindGameObjectsWithTag("Python").Length != 0)
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Python").Length; i++)
                {
                    if (Random.Range(1, 100) >= 80 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Rabbit")[Random.Range(0, GameObject.FindGameObjectsWithTag("Rabbit").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 70 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Frog")[Random.Range(0, GameObject.FindGameObjectsWithTag("Frog").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 50 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Cat")[Random.Range(0, GameObject.FindGameObjectsWithTag("Cat").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 60 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Bass")[Random.Range(0, GameObject.FindGameObjectsWithTag("Bass").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 20 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Aligator")[Random.Range(0, GameObject.FindGameObjectsWithTag("Aligator").Length)]);
                    }
                }
            }
            //CAT HUNTING
            if (GameObject.FindGameObjectsWithTag("Cat").Length != 0)
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cat").Length; i++)
                {
                    if (Random.Range(1, 100) >= 80 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Bass")[Random.Range(0, GameObject.FindGameObjectsWithTag("Bass").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 70 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Rabbit")[Random.Range(0, GameObject.FindGameObjectsWithTag("Rabbit").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 60 - nightBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Frog")[Random.Range(0, GameObject.FindGameObjectsWithTag("Frog").Length)]);
                    }
                }
            }
            //ALLIGATOR HUNTING
            if (GameObject.FindGameObjectsWithTag("Aligator").Length != 0)
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Aligator").Length; i++)
                {
                    if (Random.Range(1, 100) >= 80 - dayBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Rabbit")[Random.Range(0, GameObject.FindGameObjectsWithTag("Rabbit").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 70 - dayBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Frog")[Random.Range(0, GameObject.FindGameObjectsWithTag("Frog").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 50 - dayBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Cat")[Random.Range(0, GameObject.FindGameObjectsWithTag("Cat").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 60 - dayBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Bass")[Random.Range(0, GameObject.FindGameObjectsWithTag("Bass").Length)]);
                    }
                    else if (Random.Range(1, 100) >= 20 - dayBonus)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Python")[Random.Range(0, GameObject.FindGameObjectsWithTag("Python").Length)]);
                    }
                }
            }
            /*
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }*/
            animalSpawner.GetComponent<BasicAnimalSpawner>().animalsSpawned = 0;
        }
        if (InvasivecurrentValue < InvasivepreviousValue)
        {
            Debug.Log("Invasive func was called");
            //Spawn Invasive
            for (int i = 0; i <= Random.Range(0, 3); i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnPython();
            }
            for (int i = 0; i <= Random.Range(0, 5); i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnCat();
            }
        }
    }
    public float GameTimeInSeconds = 720;
    public float invasiveSpawnDelay = 180;
    public float NextHuntDelay = 120;
    public float NextAnimalSpawnDelay = 60;
    void setGameTimeUI()
    {

        float invasiveSpawnTime = invasiveSpawnDelay - (timeElapsed % invasiveSpawnDelay);
        float NextHuntTime = NextHuntDelay - (timeElapsed % NextHuntDelay);
        float NextAnimalSpawn = NextAnimalSpawnDelay - (timeElapsed % NextAnimalSpawnDelay);

        float GameLeftInseconds = GameTimeInSeconds - (timeElapsed % GameTimeInSeconds);

        int GameMinutes = (int)(GameLeftInseconds / 60);
        int Gameseconds = (int)(GameLeftInseconds - (GameMinutes * 60));
        TimeLeft.text = "Time Left: " + GameMinutes + ":" + Gameseconds;

        int invasiveMinutes = (int)(invasiveSpawnTime / 60);
        int Invasiveseconds = (int)(invasiveSpawnTime - (invasiveMinutes * 60));
        NextInvasiveSpawnText.text = "Next Invasive Spawn: " + invasiveMinutes + ":" + Invasiveseconds;

        int NextHuntMinutes = (int)(NextHuntTime / 60);
        int nextHuntSeconds = (int)(NextHuntTime - (NextHuntMinutes * 60));
        NextHuntText.text = "Next Hunt: " + NextHuntMinutes + ":" + nextHuntSeconds;

        int NextAnimalMinutes = (int)(NextAnimalSpawn / 60);
        int NextAnimalSeconds = (int)(NextAnimalSpawn - (NextAnimalMinutes * 60));
        NextAnimalText.text = "Next Animal Spawn: " + NextAnimalMinutes + ":" + NextAnimalSeconds;


        //this should not be here
        //this should not be here
        BasicAnimalSpawner Spawner = animalSpawner.GetComponent<BasicAnimalSpawner>();

        animalspawned = Spawner.maxAnimals - Spawner.animalsSpawned;
        TotalSpawnedText.text = animalspawned.ToString();

    }
    void resetSpawn()
    {

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
