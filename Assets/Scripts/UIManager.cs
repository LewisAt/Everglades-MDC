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

     //1 = danger 2 = warning 3 = neutral 4 = warning 5 = danger 

        public int setAligatorCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return alligatorCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return alligatorCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return alligatorCountHurricane;
                }
                return CurrentalligatorCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    alligatorCountDay = value;
                    CurrentalligatorCount = alligatorCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    alligatorCountNight = value;
                    CurrentalligatorCount = alligatorCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    alligatorCountHurricane = value;
                    CurrentalligatorCount = alligatorCountHurricane;
                    return;
                }
                CurrentalligatorCount = value;
            }
        }

        public int setToadCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return toadCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return toadCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return toadCountHurricane;
                }
                return CurrenttoadCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    toadCountDay = value;
                    CurrenttoadCount = toadCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    toadCountNight = value;
                    CurrenttoadCount = toadCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    toadCountHurricane = value;
                    CurrenttoadCount = toadCountHurricane;
                    return;
                }
                CurrenttoadCount = value;
            }
        }

        public int setRabbitCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return rabbitCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return rabbitCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return rabbitCountHurricane;
                }
                return CurrentrabbitCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    rabbitCountDay = value;
                    CurrentrabbitCount = rabbitCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    rabbitCountNight = value;
                    CurrentrabbitCount = rabbitCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    rabbitCountHurricane = value;
                    CurrentrabbitCount = rabbitCountHurricane;
                    return;
                }
                CurrentrabbitCount = value;
            }
        }

        public int setBassCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return bassCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return bassCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return bassCountHurricane;
                }
                return CurrentbassCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    bassCountDay = value;
                    CurrentbassCount = bassCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    bassCountNight = value;
                    CurrentbassCount = bassCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    bassCountHurricane = value;
                    CurrentbassCount = bassCountHurricane;
                    return;
                }
                CurrentbassCount = value;
            }
        }

        public int setCatCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return catCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return catCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return catCountHurricane;
                }
                return CurrentcatCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    catCountDay = value;
                    CurrentcatCount = catCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    catCountNight = value;
                    CurrentcatCount = catCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    catCountHurricane = value;
                    CurrentcatCount = catCountHurricane;
                    return;
                }
                CurrentcatCount = value;
            }
        }

        public int setPythonCount
        {
            get
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    return pythonCountDay;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    return pythonCountNight;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    return pythonCountHurricane;
                }
                return CurrentpythonCount;
            }
            set
            {
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
                {
                    pythonCountDay = value;
                    CurrentpythonCount = pythonCountDay;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
                {
                    pythonCountNight = value;
                    CurrentpythonCount = pythonCountNight;
                    return;
                }
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
                {
                    pythonCountHurricane = value;
                    CurrentpythonCount = pythonCountHurricane;
                    return;
                }
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
    void Start()
    {
        SceneManager.sceneLoaded += setCorrectAnimalPopulation;
        animalPool = GameObject.FindGameObjectWithTag("Animal Pool").GetComponent<AnimalPool>();
        setAligatorCount = animalPool.aligators.Length;
        setToadCount = animalPool.toads.Length;
        setRabbitCount = animalPool.rabbits.Length;
        setBassCount = animalPool.bass.Length;
        setCatCount = animalPool.cats.Length;
        setPythonCount = animalPool.pythons.Length;
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
            return;
        }


        
        if(onFirstLoadOfHurricane == false && SceneManager.GetActiveScene().name == "Hurricane")
        {
             setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            GameDialog.playerHurricaneSceneEntered();
            onFirstLoadOfHurricane = true;


        
        }
        if (onFirstLoadOfNight == false && SceneManager.GetActiveScene().name == "Night")
        {
            setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            GameDialog.playerNightSceneEntered();
            onFirstLoadOfNight = true;

        }
        if (onFirstLoadOfDay == false && SceneManager.GetActiveScene().name == "TerrainTest")
        {

            setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            Debug.Log("Day");
            Debug.Log(setAligatorCount);
            Debug.Log(setBassCount);
            Debug.Log(setRabbitCount);
            Debug.Log(setPythonCount);
            Debug.Log(setCatCount);
            Debug.Log(setToadCount);
            GameDialog.playerDaySceneEntered();
            onFirstLoadOfDay = true;


        }
        

        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            setToadCount +=1;
        }
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Animal Counts:");
                Debug.Log("Alligator Count: " + setAligatorCount);
                Debug.Log("Toad Count: " + setToadCount);
                Debug.Log("Rabbit Count: " + setRabbitCount);
                Debug.Log("Bass Count: " + setBassCount);
                Debug.Log("Cat Count: " + setCatCount);
                Debug.Log("Python Count: " + setPythonCount);
            }
        }
        RecieveChecklistInfo();
    }
    void setCorrectAnimalPopulation(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded " + scene.name);
        StartCoroutine(delayForAnimalpool(scene.name));
        
    }
    IEnumerator delayForAnimalpool(string scene)
    {
        yield return new WaitForSeconds(1);
        if(scene == "TerrainTest" && onFirstLoadOfDay == true)
        {
            animalPool.SpawnAligator(alligatorCountDay); 
            animalPool.SpawnToad(toadCountDay);
            animalPool.SpawnRabbit(rabbitCountDay);
            animalPool.SpawnBass(bassCountDay);
            animalPool.SpawnCat(catCountDay);
            animalPool.SpawnPython(pythonCountDay);

        }
        if(scene == "Night" && onFirstLoadOfNight == true)
        {
            animalPool.SpawnAligator(alligatorCountNight);
            animalPool.SpawnToad(toadCountNight);
            animalPool.SpawnRabbit(rabbitCountNight);
            animalPool.SpawnBass(bassCountNight);
            animalPool.SpawnCat(catCountNight);
            animalPool.SpawnPython(pythonCountNight);

        }
        if(scene == "Hurricane" && onFirstLoadOfHurricane == true)
        {
            animalPool.SpawnAligator(alligatorCountHurricane);
            animalPool.SpawnToad(toadCountHurricane);
            animalPool.SpawnRabbit(rabbitCountHurricane);
            animalPool.SpawnBass(bassCountHurricane);
            animalPool.SpawnCat(catCountHurricane);
            animalPool.SpawnPython(pythonCountHurricane);

        }
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
        setAligatorCount += 1;
    }
    public void spawnToad()
    {
        animalPool.SpawnToad();
        setToadCount += 1;
    }
    public void spawnRabbit()
    {
        animalPool.SpawnRabbit();
        setRabbitCount += 1;
    }
    public void spawnBass()
    {
        animalPool.SpawnBass();
        setBassCount += 1;
    }
    public void spawnCat()
    {
        animalPool.SpawnCat();
        setCatCount += 1;
    }
    public void spawnPython()
    {
        animalPool.SpawnPython();
        setPythonCount += 1;
    }
    public void deSpawnAlligator()
    {
        animalPool.DeactiveAligator();
        setPythonCount -= 1;
    }
    public void deSpawnToad()
    {
        animalPool.DeactiveToad();
        setToadCount -= 1;
    }
    public void deSpawnRabbit()
    {
        animalPool.DeactiveRabbit();
        setRabbitCount -= 1;

    }
    public void deSpawnBass()
    {
        animalPool.DeactiveBass();
        setBassCount -= 1;
    }
    public void deSpawnCat()
    {
        animalPool.DeactiveCat();
        setCatCount -= 1;
    }
    public void deSpawnPython()
    {
        animalPool.DeactivePython();
        setPythonCount -= 1;
    }

    


}

