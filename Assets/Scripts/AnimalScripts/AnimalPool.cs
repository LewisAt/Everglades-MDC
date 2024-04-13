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

    void  Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("Player").GetComponent<UIManager>();
    }

    public void SpawnAligator(int count = 0)
    {
        ActivateGameObject(aligators);
        if (count > 0)
        {
            ActivateGameobjectWithCount(toads, count);
        }
    }

    public void SpawnToad(int count = 0)
    {
        ActivateGameObject(toads);
        if (count > 0)
        {
            ActivateGameobjectWithCount(toads, count);
        }
    }

    public void SpawnRabbit(int count = 0)
    {
        ActivateGameObject(rabbits);
        if (count > 0)
        {
            ActivateGameobjectWithCount(rabbits, count);
        }
    }

    public void SpawnBass(int count = 0)
    {
        ActivateGameObject(bass);
        if (count > 0)
        {
            ActivateGameobjectWithCount(bass, count);
        }
    }

    public void SpawnCat(int count = 0)
    {
        ActivateGameObject(cats);
        if (count > 0)
        {
            ActivateGameobjectWithCount(cats, count);
        }
    }

    public void SpawnPython(int count = 0)
    {
        ActivateGameObject(pythons);
        if (count > 0)
        {
            ActivateGameobjectWithCount(pythons, count);
        }
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
    public int returactiveAligator()
    {
        int j = 0;
        for (int i = 0; i < aligators.Length; i++)
        {
            if (aligators[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveToad()
    {
        int j = 0;
        for (int i = 0; i < toads.Length; i++)
        {
            if (toads[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveRabbit()
    {
        int j = 0;
        for (int i = 0; i < rabbits.Length; i++)
        {
            if (rabbits[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveBass()
    {
        int j = 0;
        for (int i = 0; i < bass.Length; i++)
        {
            if (bass[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveCat()
    {
        int j = 0;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactivePython()
    {
        int j = 0;
        for (int i = 0; i < pythons.Length; i++)
        {
            if (pythons[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    


    private void ActivateGameObject(GameObject[] gameObjects)
    {
        while (gameObjects == null)
        {
            Debug.Log("gameObjects is null");
            break;
        }
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
    private void ActivateGameobjectWithCount(GameObject[] gameObjects, int count)
    {
        for (int i = 0; i < count; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }



    private void SceneTransitionedSetAnimals()
    {
    }
}
