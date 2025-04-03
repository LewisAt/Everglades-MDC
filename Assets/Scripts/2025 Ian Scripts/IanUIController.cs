//Ian Marshburn
//Script handles the pause menu functionality of the PC version of the game
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IanUIController : MonoBehaviour
{
    //variable declarations
    //singleton setup
    public static IanUIController Instance;
    public GameObject pauseMenu, winGameButton;

    public Slider trashSlider;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    //toggle for pause menu
    public void PauseMenuToggle()
    {
        if (pauseMenu.activeSelf)
        {//unpause
            Time.timeScale = 1;
            StartCoroutine(LockCursor());
            pauseMenu.SetActive(false);
        }
        else
        {//pause
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
    }

    private IEnumerator LockCursor()
    {//locks cursor one frame after you unpause the game. This just helps with stuff
        yield return new WaitForEndOfFrame();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GameWin()
    {
        //I want a way to 
        winGameButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
