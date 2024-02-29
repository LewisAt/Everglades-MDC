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

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void menuTransition()
    {
        currMenu.SetActive(false);
        nextMenu.SetActive(true);
    }
}
