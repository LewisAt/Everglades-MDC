using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TimeAndGameManager : MonoBehaviour
{
    [SerializeField ]
    public float GameLength = 12;
    //An object to hold our sun
    [SerializeField]
    private GameObject TimeCore;
    [SerializeField]
    private GameObject Sun;
    [SerializeField]
    private Material SunSkybox;
    //and object to hold our moon  both of these are pivots
    [SerializeField]
    private GameObject Moon;
    [SerializeField]
    private Material MoonSkybox;
    // a list of objects based on the class below. it hold variables that we use to change the skybox material
    // we have we could later just use more skyboxes and have a main one lerp between those

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
    int dayBonus;
    int nightBonus;
    //public GameObject[] buttons;

    //on the first frame of the game this acitvates and does some simple math for us before contining to the rest of the code.
    private void Awake()
    {
        Sun.gameObject.SetActive(true);
        Moon.gameObject.SetActive(false);
        HoursInAMinut = 24 / GameLength;
    }

    public void Update()
    {
        internalclock();
        //GetCurrentSkyInfo();
        setGameTimeUI();
        if(CurrentTime >= 12)
        {
            RenderSettings.skybox = MoonSkybox;
            Sun.gameObject.SetActive(false);
            Moon.gameObject.SetActive(true);
        }
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
        //Animal Spawnining 

        if (timeElapsed % 120 == 0)
        {
            int SpawnFrog = Random.Range(1, 6);
            int SpawnAligator = Random.Range(2, 4);
            int SpawnRabbit = Random.Range(3, 5);
            int SpawnBass = Random.Range(2, 6);
            for (int i = 0; i < SpawnFrog; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnAFrog();
            }
            for (int i = 0; i < SpawnAligator; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnAligator();
            }
            for (int i = 0; i < SpawnRabbit; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnRabbit();
            }
            for (int i = 0; i < SpawnBass; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnFish();
            }
        }
        //Every 3 mins spawn invasive species
        if (timeElapsed % 180 == 0)
        {
            int spawnPython = Random.Range(2, 3);
            int spawnCat = Random.Range(3, 5);
   
            for (int i = 0; i < spawnPython; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnPython();
            }
            for (int i = 0; i < spawnCat; i++)
            {
                animalSpawner.GetComponent<BasicAnimalSpawner>().spawnCat();
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
    void UpdateSunRotation()
    {
        SunsCurrentHourRotation = Quaternion.Euler(TheCurrentTimeInRotation, 0, 0);

        Quaternion sunPosition = Quaternion.Lerp(Sun.transform.rotation, SunsCurrentHourRotation, 1f);
        TimeCore.transform.rotation = sunPosition;
    }
   
    void internalclock()
    {
        timeElapsed += Time.deltaTime; // starts counting the number of seconds that pass since the start of the game I think there is one command in unity for this
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
