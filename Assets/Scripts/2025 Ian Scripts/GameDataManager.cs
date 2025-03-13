//Ian Marshburn
//Script handles game data management
//This includes storing important UI to be updated, objects to spawn, and the number and name of those objects

using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //populate dictionary
        foreach (var pair in allGameData)
        {
            dataDictionary[pair.nameTag] = pair.gameData;
        }

        //FIXME: test access the values
        if (dataDictionary.ContainsKey("Alligator"))
        {
            DataValues tempStruct = dataDictionary["Alligator"];
            Debug.Log("GameObject: {tempStruct.spawnPrefab}");
            Debug.Log("Toggle: {tempStruct.checklistToggle}");

            tempStruct.checklistToggle.isOn = true;
        }
    }
}
