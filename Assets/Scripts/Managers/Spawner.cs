using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Animal;
    public int spawnRange = 25;

    public void SpawnSpecificAnimals()
    {
        float x = Random.Range(-spawnRange + transform.position.x, spawnRange + transform.position.x);
        float z = Random.Range(-spawnRange + transform.position.z, spawnRange + transform.position.z);
        Instantiate(Animal, new Vector3(x,50,z), Quaternion.identity);

    }
}

