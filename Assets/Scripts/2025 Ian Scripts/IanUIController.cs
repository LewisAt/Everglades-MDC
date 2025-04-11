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
    public GameObject pauseMenu, winGameButton, tutorialMenu;

    //used for throw away trash remaining
    public Slider trashSlider;

    public bool isVR = false;
    [Tooltip("Check this to use the tutorial menu and disallow unpausing at the start")]
    public bool tutorialPC;

    // Start is called before the first frame update
    void Start()
    {
        if (tutorialPC && !isVR)
        {
            //pause game so the tutorial menu can be interacted with.
            Time.timeScale = 0;
            tutorialMenu.SetActive(true);
        }
        Instance = this;
        Debug.Log("Instance = " + Instance.name);
    }

    //toggle for pause menu
    public void PauseMenuToggle()
    {
        if (tutorialPC)
        {
            Debug.LogError("cannot show pause menu when tutorial is active");
        }
        else
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
    }

    //toggles the tutorial menu
    //called at the start and from a menu button
    public void ToggleTutorialMenu()
    {
        if (tutorialPC)
        {//unpause game
            Time.timeScale = 1;
            StartCoroutine(LockCursor());
            tutorialMenu.SetActive(false);
            tutorialPC = !tutorialPC;
        }
        else
        {
            if (pauseMenu.activeSelf)
            {//if this was triggered from the pause menu, disable that UI
                pauseMenu.SetActive(false);
            }
            //pause
            Time.timeScale = 0;
            tutorialMenu.SetActive(true);

            tutorialPC = !tutorialPC;
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
        Debug.Log("player met win criteria!");
        winGameButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
