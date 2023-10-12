using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int sceneNum;
    public GameObject instructions;
    public GameObject main;
    public GameObject animal;
    public GameObject time;
    public GameObject source;
    public GameObject croc;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableInstructions()
    {
        instructions.SetActive(true);
    }
    public void DisableInstructions()
    {
        instructions.SetActive(false);
    }

    public void ToMainMenu()
    {
        source.SetActive(false);
        main.SetActive(true);
    }
    public void ToAnimalMenu()
    {
        main.SetActive(false);
        animal.SetActive(true);
    }
    public void ToTimeMenu()
    {
        main.SetActive(false);
        time.SetActive(true);
    }

    public void SpawnCroc()
    {
        //Input Code
    }
}
