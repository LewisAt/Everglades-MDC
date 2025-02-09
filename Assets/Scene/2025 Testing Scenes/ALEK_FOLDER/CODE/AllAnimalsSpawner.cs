using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AllAnimalsSpawner : MonoBehaviour
{
    public Transform spawnPoint; // Assign an empty GameObject in front of the player

    public GameObject alligatorPrefab;
    public GameObject rabbitPrefab;
    public GameObject catPrefab;
    public GameObject opossumPrefab;
    public GameObject heronPrefab;
    public GameObject egretPrefab;
    public GameObject frogPrefab;
    public GameObject pythonPrefab;

    private GameObject spawnedAnimal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnAnimal(alligatorPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnAnimal(rabbitPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnAnimal(catPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnAnimal(opossumPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnAnimal(heronPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnAnimal(egretPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SpawnAnimal(frogPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SpawnAnimal(pythonPrefab);
    }

    void SpawnAnimal(GameObject animalPrefab)
    {
        if (animalPrefab == null)
        {
            UnityEngine.Debug.LogError("No prefab assigned for this animal!");
            return;
        }

        // Destroy the previous animal before spawning a new one
        if (spawnedAnimal != null)
        {
            Destroy(spawnedAnimal);
        }

        spawnedAnimal = Instantiate(animalPrefab, spawnPoint.position, Quaternion.identity);

        // Move the spawned animal using its AI script
        AnimalAI ai = spawnedAnimal.GetComponent<AnimalAI>();
        if (ai != null)
        {
            ai.MoveToPlayer(spawnPoint.position);
        }
    }
}