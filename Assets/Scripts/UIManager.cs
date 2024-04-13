using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text infoText;
    public GamePlayDialog GameDialog;

    private float timerValue = 0;
    private int collectedInfo;

    public int lossScene;

    public Toggle alligatorCheck;
    public Toggle toadCheck;
    public Toggle rabbitCheck;
    public Toggle bassCheck;
    public Toggle catCheck;
    public Toggle pythonCheck;
    public Toggle oilCheck;
    public Toggle litterCheck;
    public Toggle mangroovesCheck;

    public Slider alligatorMeter;
    public Slider toadMeter;
    public Slider rabbitMeter;
    public Slider bassMeter;
    public Slider catMeter;
    public Slider pythonMeter;
    public Text statusText;

    private int CurrentalligatorCount;
    private int CurrenttoadCount;
    private int CurrentrabbitCount;
    private int CurrentbassCount;
    private int CurrentcatCount;
    private int CurrentpythonCount;

    private int alligatorCountDay;
    private int toadCountDay;
    private int rabbitCountDay;
    private int bassCountDay;
    private int catCountDay;
    private int pythonCountDay;

    private int alligatorCountNight;
    private int toadCountNight;
    private int rabbitCountNight;
    private int bassCountNight;
    private int catCountNight;
    private int pythonCountNight;

    private int alligatorCountHurricane;
    private int toadCountHurricane;
    private int rabbitCountHurricane;
    private int bassCountHurricane;
    private int catCountHurricane;
    private int pythonCountHurricane;
    public static UIManager instance;

    private int Status = 3; //1 = danger 2 = warning 3 = neutral 4 = warning 5 = danger 



    public int setAligatorCount
    {
        get
        {
            return CurrentalligatorCount;
        }
        set
        {
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                alligatorCountDay = value;
            }
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                alligatorCountNight= value;
            }
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                alligatorCountHurricane = value;
            }
            Debug.Log(value);
            CurrentalligatorCount = value;
        }
    }
    public int setToadCount
    {
        get
        {
            return CurrenttoadCount;
        }
        set
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                toadCountDay = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                toadCountNight = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                toadCountHurricane = value;
            }
            Debug.Log(value);
            CurrenttoadCount = value;
        }
    }

    public int setRabbitCount
    {
        get
        {
            return CurrentrabbitCount;
        }
        set
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                rabbitCountDay = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                rabbitCountNight = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                rabbitCountHurricane = value;
            }
            Debug.Log(value);
            CurrentrabbitCount = value;
        }
    }

    public int setBassCount
    {
        get
        {
            return CurrentbassCount;
        }
        set
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                bassCountDay = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                bassCountNight = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                bassCountHurricane = value;
            }
            Debug.Log(value);
            CurrentbassCount = value;
        }
    }

    public int setCatCount
    {
        get
        {
            return CurrentcatCount;
        }
        set
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                catMeter.value = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                catMeter.value = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                catMeter.value = value;
            }
            Debug.Log(value);
            CurrentcatCount = value;
        }
    }

    public int setPythonCount
    {
        get
        {
            return CurrentpythonCount;
        }
        set
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
            {
                pythonCountDay = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
            {
                pythonCountNight = value;
            }
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
            {
                pythonCountHurricane = value;
            }
            Debug.Log(value);
            CurrentpythonCount = value;
        }
    }

 

    private bool onFirstLoadOfNight = false;
    private bool onFirstLoadOfHurricane = false;
    private bool onFirstLoadOfDay = false;




    public GameObject mainMenu;
    public GameObject animalMenu;
    public GameObject sceneMenu;
    public GameObject meterMenu;
    public GameObject finalMenu;
    private AnimalPool animalPool;

    private void Awake()
    {
        collectedInfo = 0;
        timerValue = 600;
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    [HideInInspector]
    public int min = 0;
    public int sec = 0;
    private void Update()
    {
        timerValue -= Time.deltaTime;

        min = Mathf.FloorToInt(timerValue / 60);
        sec = Mathf.FloorToInt(timerValue % 60);
        timerText.text = "Time Left - " + string.Format("{0:00}:{1:00}", min, sec);

        infoText.text = collectedInfo.ToString() + "/9 Info Collected";




        if (collectedInfo == 9)
        {
            mainMenu.SetActive(false);
            animalMenu.SetActive(false);
            sceneMenu.SetActive(false);
            meterMenu.SetActive(false);
            finalMenu.SetActive(true);
        }

        if (timerValue <= 0)
        {
            SceneManager.LoadScene(lossScene);
        }

        if (timerValue % 60 == 0)
        {
            //Destroy native animals
        }

        if (timerValue % 90 == 0)
        {
            //Spawn new invasive animals
        }
        

        



        // Adjust Animal Sliders according to value (5 states)

    }
    void FixedUpdate()
    {
        if(animalPool == null)
        {
            animalPool = GameObject.FindGameObjectWithTag("Animal Pool").GetComponent<AnimalPool>();
        }


        
        if(onFirstLoadOfHurricane == false && SceneManager.GetActiveScene().name == "Hurricane")
        {
            onFirstLoadOfHurricane = true;
            setAligatorCount = animalPool.aligators.Length;
            setToadCount = animalPool.toads.Length;
            setRabbitCount = animalPool.rabbits.Length;
            setBassCount = animalPool.bass.Length;
            setCatCount = animalPool.cats.Length;
            setPythonCount = animalPool.pythons.Length;
            GameDialog.playerHurricaneSceneEntered();

        
        }
        if (onFirstLoadOfNight == false && SceneManager.GetActiveScene().name == "Night")
        {
            onFirstLoadOfNight = true;
            setAligatorCount = animalPool.aligators.Length;
            setToadCount = animalPool.toads.Length;
            setRabbitCount = animalPool.rabbits.Length;
            setBassCount = animalPool.bass.Length;
            setCatCount = animalPool.cats.Length;
            setPythonCount = animalPool.pythons.Length;
            GameDialog.playerNightSceneEntered();
        }
        if (onFirstLoadOfDay == false && SceneManager.GetActiveScene().name == "TerrainTest")
        {
            onFirstLoadOfDay = true;
            setAligatorCount = animalPool.aligators.Length;
            setToadCount = animalPool.toads.Length;
            setRabbitCount = animalPool.rabbits.Length;
            setBassCount = animalPool.bass.Length;
            setCatCount = animalPool.cats.Length;
            setPythonCount = animalPool.pythons.Length;
            Debug.Log("Day");
            Debug.Log(setAligatorCount);
            Debug.Log(setBassCount);
            Debug.Log(setRabbitCount);
            Debug.Log(setPythonCount);
            Debug.Log(setCatCount);
            Debug.Log(setToadCount);
            GameDialog.playerDaySceneEntered();

        }
        RecieveChecklistInfo();
    }
    void RecieveChecklistInfo()
    {
        // Recieve checklist info from Checklist.cs
        if(Checklist.Croc == true && alligatorCheck.isOn == false)
        {
            alligatorCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.toad == true && toadCheck.isOn == false)
        {
            toadCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.Rabbit == true && rabbitCheck.isOn == false)
        {
            rabbitCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.bass == true && bassCheck.isOn == false)
        {
            bassCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.cat == true && catCheck.isOn == false)
        {
            catCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.python == true && pythonCheck.isOn == false)
        {
            pythonCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.oil == true && oilCheck.isOn == false)
        {
            oilCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.litter == true && litterCheck.isOn == false)
        {
            litterCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.mangroove == true && mangroovesCheck.isOn == false)
        {
            mangroovesCheck.isOn = true;
            collectedInfo++;
        }
        


    }

    public void spawnAlligator()
    {
        animalPool.SpawnAligator();
    }
    public void spawnToad()
    {
        animalPool.SpawnToad();
    }
    public void spawnRabbit()
    {
        animalPool.SpawnRabbit();
    }
    public void spawnBass()
    {
        animalPool.SpawnBass();
    }
    public void spawnCat()
    {
        animalPool.SpawnCat();
    }
    public void spawnPython()
    {
        animalPool.SpawnPython();
    }
    public void deSpawnAlligator()
    {
        animalPool.DeactiveAligator();
    }
    public void deSpawnToad()
    {
        animalPool.DeactiveToad();
    }
    public void deSpawnRabbit()
    {
        animalPool.DeactiveRabbit();
    }
    public void deSpawnBass()
    {
        animalPool.DeactiveBass();
    }
    public void deSpawnCat()
    {
        animalPool.DeactiveCat();
    }
    public void deSpawnPython()
    {
        animalPool.DeactivePython();
    }

    


}

