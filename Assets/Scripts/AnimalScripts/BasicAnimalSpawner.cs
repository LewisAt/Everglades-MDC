using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAnimalSpawner : MonoBehaviour
{
    public AnimalSpawner[] Animals;
    public int maxAnimals;
    public int animalsSpawned;
    public Text animalLeftText;
    private int animalsLeft;


    public void spawnAligator()
    {
        if (animalsSpawned >= maxAnimals)
        {
            animalsSpawned = 0;
            return;
        }
        GameObject clone = Instantiate(Animals[0].AnimalToSpawn);
        clone.tag = "Aligator";
        clone.transform.position = Animals[0].SpawnPosition.transform.position;
        animalsSpawned++;
    }
    public void spawnFish()
    {
        if (animalsSpawned >= maxAnimals)
        {
            return;
        }

        GameObject clone = Instantiate(Animals[1].AnimalToSpawn);
        clone.tag = "Fish";

        clone.transform.position = Animals[1].SpawnPosition.transform.position;
        animalsSpawned++;
    }
   
    public void spawnAFrog()
    {
        if (animalsSpawned >= maxAnimals)
        {
            return;
        }

        GameObject clone = Instantiate(Animals[2].AnimalToSpawn);
        clone.transform.position = Animals[2].SpawnPosition.transform.position;
        clone.tag = "Frog";
        animalsSpawned++;

    }
    public void spawnPython()
    {
        if (animalsSpawned >= maxAnimals)
        {
            return;
        }

        GameObject clone = Instantiate(Animals[3].AnimalToSpawn);
        clone.transform.position = Animals[3].SpawnPosition.transform.position;
        clone.tag = "Python";
        animalsSpawned++;


    }
    public void spawnRabbit()
    {
        if (animalsSpawned >= maxAnimals)
        {
            return;
        }

        GameObject clone = Instantiate(Animals[4].AnimalToSpawn);
        clone.transform.position = Animals[4].SpawnPosition.transform.position;
        clone.tag = "Rabbit";
        animalsSpawned++;

    }
    public void spawnCat()
    {
        if (animalsSpawned >= maxAnimals)
        {
            return;
        }

        GameObject clone = Instantiate(Animals[5].AnimalToSpawn);
        clone.transform.position = Animals[5].SpawnPosition.transform.position;
        clone.tag = "Cat";
        animalsSpawned++;


    }
    public void playerIncrement()
    {
        if (animalsSpawned >= maxAnimals) return;
        animalsSpawned++;
    }


    private void Update()
    {
        animalsLeft = maxAnimals - animalsSpawned;
        animalLeftText.text = animalsLeft.ToString();
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnAligator();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spawnRabbit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnPython();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            spawnCat();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnAFrog();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            spawnFish();
        }
    }

    [Serializable]

    public class AnimalSpawner
    {
        public GameObject SpawnPosition;
        public GameObject AnimalToSpawn;

    }
}
