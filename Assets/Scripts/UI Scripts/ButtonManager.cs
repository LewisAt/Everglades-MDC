using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int sceneNum;
    public GameObject animalMenu;
    public GameObject interactableMenu;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void animalTransition()
    {
        animalMenu.SetActive(false);
        interactableMenu.SetActive(true);
    }

    public void interactableTranstition()
    {
        animalMenu.SetActive(true);
        interactableMenu.SetActive(false);
    }
}
