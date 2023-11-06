using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    int SpawnedNumber = 0;
    public AnimalCreatorAndSpawner[] AnimalObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showMoreFakeObjects();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            showLessFakeObjects
                ();
        }
    }
    public void SpawnAnimal(int i)
    {
       
    }
    public void showMoreFakeObjects()
    {
        increaseCount();

        for (int i = 0; i < SpawnedNumber * (AnimalObject[0].FakeToRealRatio); i++) 
        {
            AnimalObject[0].FakeAnimalsOfSameType[i].SetActive(true);
        }

    }

    public void showLessFakeObjects()
    {
        int fakeTotal = (SpawnedNumber - 1) * AnimalObject[0].FakeToRealRatio;
        Debug.Log(fakeTotal);
        for (int i = (SpawnedNumber * AnimalObject[0].FakeToRealRatio) - 1; i >= fakeTotal; i--)
        {
            Debug.Log("removed " + i);
            AnimalObject[0].FakeAnimalsOfSameType[i].SetActive(false);
        }
        DecreaseCount();

    }
    void increaseCount()
    {
        SpawnedNumber++;

        SpawnedNumber = Mathf.Clamp(SpawnedNumber, 0, 10);
        Debug.Log(SpawnedNumber);

    }
    void DecreaseCount()
    {
        SpawnedNumber--;

        SpawnedNumber = Mathf.Clamp(SpawnedNumber, 0, 10);
        Debug.Log(SpawnedNumber);

    }


}






[Serializable]
public class AnimalCreatorAndSpawner
{
    public GameObject SpawnPosition;
    public GameObject AnimalToSpawn;
    public int FakeToRealRatio = 3;
    public GameObject[] FakeAnimalsOfSameType;


}
