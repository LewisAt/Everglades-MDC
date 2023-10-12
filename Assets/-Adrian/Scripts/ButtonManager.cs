using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int sceneNum;
    public Image instructions;

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
        instructions.enabled = true;
    }
    public void DisableInstructions()
    {
        instructions.enabled = false;
    }
}
