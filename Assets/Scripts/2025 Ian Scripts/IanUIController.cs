//Ian Marshburn
//Script handles the pause menu functionality of the PC version of the game
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IanUIController : MonoBehaviour
{
    //variable declarations
    //singleton setup
    public static IanUIController Instance;
    public GameObject pauseMenu, winGameButton;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //toggle for pause menu
    public void PauseMenuToggle()
    {

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
