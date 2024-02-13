using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infointraction : MonoBehaviour
{

    public string infoTodisplay;
    public Text TextBoxToReveal;
    public GameObject CanvasBase;
    // Start is called before the first frame update
    public void enableAll()
    {
        CanvasBase.SetActive(true);
        TextBoxToReveal.text = infoTodisplay;
    }
}
