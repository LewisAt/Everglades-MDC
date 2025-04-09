//Ian Marshburn
//Script handles game data management
//This includes storing important UI to be updated, objects to spawn, and the number and name of those objects
//We're spitballing these functions real quick
//Let's pray: God, bless this script, and may our syntax ever be consistent. May our comments be informative, unless it is your will that our code confound the evil one.
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DataValues
{
    public Toggle checklistToggle;
    public Slider populationSlider;
    public GameObject spawnPrefab;
    [HideInInspector] public int objectCount;
}

[System.Serializable]
public struct GameKeyValuePair
{
    [Tooltip("This should match the tag of the Spawn Prefab")]
    public string nameTag;
    public DataValues gameData;
}

public class GameDataManager : MonoBehaviour
{
    //variable declarations
    //singleton setup
    public static GameDataManager Instance;

    //this is what you set up in the inspector...
    [SerializeField] private List<GameKeyValuePair> allGameData = new();
    //...but this is what you access the data through
    private Dictionary<string, DataValues> dataDictionary = new();

    [HideInInspector] public int trashRemaining = 0;

    private bool allChecklistFilled = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //populate dictionary
        foreach (var pair in allGameData)
        {
            dataDictionary[pair.nameTag] = pair.gameData;
        }

        //Set up initial values for animal sliders
        foreach(DataValues value in dataDictionary.Values)
        {
            int count = GameObject.FindGameObjectsWithTag(value.spawnPrefab.tag).Length;
            //this doesn't do anything about "ideal" population values
            if (value.populationSlider != null)
            {
                value.populationSlider.maxValue = count;
                value.populationSlider.value = count;
            }
        }

        //FIXME: test access the values
        if (dataDictionary.ContainsKey("Alligator"))
        {
            DataValues tempStruct = dataDictionary["Alligator"];
            Debug.Log("GameObject: {tempStruct.spawnPrefab}");
            Debug.Log("Toggle: {tempStruct.checklistToggle}");

            tempStruct.checklistToggle.isOn = true;
        }

        //set trash remaining to amount of trash in scene
        trashRemaining = GameObject.FindGameObjectsWithTag("trash").Length;
        IanUIController.Instance.trashSlider.maxValue = trashRemaining;
        IanUIController.Instance.trashSlider.value = trashRemaining;
        Debug.Log("Trash in scene: " + trashRemaining);
    }

    //call this when interactive with objects to record them
    public void FillChecklist(string objectTag)
    {
        if (dataDictionary.ContainsKey(objectTag))
        {
            DataValues tempStruct = dataDictionary[objectTag];
            tempStruct.checklistToggle.isOn = true;
            ParseChecklist();
        }
        else
        {
            Debug.LogError("Invalid tag: " + objectTag);
        }
    }

    private void ParseChecklist()
    {
        //reset to true before checking if it should be false
        allChecklistFilled = true;
        foreach( DataValues value in dataDictionary.Values)
        {
            if (value.checklistToggle.isOn != true)
            {
                allChecklistFilled = false;
            }
        }
        if (allChecklistFilled && trashRemaining <= 0)
        {
            IanUIController.Instance.GameWin();
        }
    }

    public void ReduceTrash()
    {
        trashRemaining--;
        IanUIController.Instance.trashSlider.value = trashRemaining;
        if (trashRemaining <= 0 && allChecklistFilled)
        {
            IanUIController.Instance.GameWin();
        }
    }
}
