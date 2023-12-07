using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimalSpawner : MonoBehaviour
{
    public AnimalSpawner[] Animals;
    public int maxAnimals;
    public int animalsSpawned;

    public void spawnAligator()
    {
        GameObject clone = Instantiate(Animals[0].AnimalToSpawn);
        clone.transform.position = Animals[0].SpawnPosition.transform.position;
        animalsSpawned++;
    }
    public void spawnFish()
    {
        GameObject clone = Instantiate(Animals[1].AnimalToSpawn);
        clone.transform.position = Animals[1].SpawnPosition.transform.position;
        animalsSpawned++;
    }
   
    public void spawnAFrog()
    {
        GameObject clone = Instantiate(Animals[2].AnimalToSpawn);
        clone.transform.position = Animals[2].SpawnPosition.transform.position;
        animalsSpawned++;
    }
    public void spawnPython()
    {
        GameObject clone = Instantiate(Animals[3].AnimalToSpawn);
        clone.transform.position = Animals[3].SpawnPosition.transform.position;
    }
    public void spawnRabbit()
    {
        GameObject clone = Instantiate(Animals[4].AnimalToSpawn);
        clone.transform.position = Animals[4].SpawnPosition.transform.position;
        animalsSpawned++;
    }
    public void spawnCat()
    {
        GameObject clone = Instantiate(Animals[5].AnimalToSpawn);
        clone.transform.position = Animals[5].SpawnPosition.transform.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnAligator();
        }
    }

    void AnimalToCount()
    {
        TrackAnimalCount.addtoPopulationCount(this.gameObject.tag);
    }

    [Serializable]

    public class AnimalSpawner
    {
        public GameObject SpawnPosition;
        public GameObject AnimalToSpawn;

    }
}
