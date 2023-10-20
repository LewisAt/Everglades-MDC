using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int sceneNum;
    public GameObject currMenu;
    public GameObject nextMenu;

    public GameObject currInfo;
    public GameObject OtherInfoA;
    public GameObject OtherInfoB;
    public GameObject OtherInfoC;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToNextMenu()
    {
        currMenu.SetActive(false);
        nextMenu.SetActive(true);
    }
    public void SummonAnimalInfo()
    {
        OtherInfoA.SetActive(false);
        OtherInfoB.SetActive(false);
        OtherInfoC.SetActive(false);
        currInfo.SetActive(true);
    }
}
