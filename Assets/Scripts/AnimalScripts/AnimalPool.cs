using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPool : MonoBehaviour
{


    public GameObject[] aligators;

    public GameObject[] toads;

    public GameObject[] rabbits;

    public GameObject[] bass;

    public GameObject[] cats;

    public GameObject[] pythons;

    private UIManager uiManager;

    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Player").GetComponent<UIManager>();
    }

    public void SpawnAligator()
    {
        ActivateGameObject(aligators);
    }

    public void SpawnToad()
    {
        ActivateGameObject(toads);
    }

    public void SpawnRabbit()
    {
        ActivateGameObject(rabbits);
    }

    public void SpawnBass()
    {
        ActivateGameObject(bass);
    }

    public void SpawnCat()
    {
        ActivateGameObject(cats);
    }

    public void SpawnPython()
    {
        ActivateGameObject(pythons);
    }


    public void DeactiveAligator()
    {
        DeactiveGameObject(aligators);
    }
    public void DeactiveToad()
    {
        DeactiveGameObject(toads);
    }
    public void DeactiveRabbit()
    {
        DeactiveGameObject(rabbits);
    }
    public void DeactiveBass()
    {
        DeactiveGameObject(bass);
    }
    public void DeactiveCat()
    {
        DeactiveGameObject(cats);
    }
    public void DeactivePython()
    {
        DeactiveGameObject(pythons);
    }


    private void ActivateGameObject(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (!gameObjects[i].activeInHierarchy)
            {
                gameObjects[i].SetActive(true);
                break;
            }
        }
    }
    
    public void DeactiveGameObject(GameObject[] gameObject)
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            if (!gameObject[i].activeInHierarchy)
            {
                gameObject[i].SetActive(false);
                break;
            }
        }
    }
}
