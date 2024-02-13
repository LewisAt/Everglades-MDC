using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int sceneNum;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
