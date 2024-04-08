using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text infoText;

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

    public int alligatorCount;
    public int toadCount;
    public int rabbitCount;
    public int bassCount;
    public int catCount;
    public int pythonCount;

    public GameObject mainMenu;
    public GameObject animalMenu;
    public GameObject sceneMenu;
    public GameObject meterMenu;
    public GameObject finalMenu;

    private void Start()
    {
        collectedInfo = 0;
        timerValue = 600;

        DontDestroyOnLoad(this);

        alligatorCount = 50;
        toadCount = 50;
        rabbitCount = 50;
        bassCount = 50;  
        catCount = 25;
        pythonCount = 25;
    }

    private void Update()
    {
        timerValue -= Time.deltaTime;

        int min = Mathf.FloorToInt(timerValue / 60);
        int sec = Mathf.FloorToInt(timerValue % 60);
        timerText.text = "Time Left - " + string.Format("{0:00}:{1:00}", min, sec);

        infoText.text = collectedInfo.ToString() + "/9 Info Collected";


        if (alligatorCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (toadCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (rabbitCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (bassCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (catCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (pythonCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (oilCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (litterCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;
        if (mangroovesCheck.GetComponent<Toggle>().isOn == true) collectedInfo++;

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
}
