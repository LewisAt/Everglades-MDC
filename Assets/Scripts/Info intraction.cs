using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infointraction : MonoBehaviour
{
    [TextArea(15, 20)]
    public string infoTodisplay;
    public Text TextBoxToReveal;
    private GameObject Player;
    public GameObject CanvasBase;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    public void enableAll()
    {
        if(CanvasBase.activeSelf)
        {
            CanvasBase.SetActive(false);
            return;
        }
        CanvasBase.SetActive(true);
        TextBoxToReveal.text = infoTodisplay;
        StartCoroutine(Disable());
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(15);
        if(CanvasBase.activeSelf)
        {
            CanvasBase.SetActive(false);

        }
    }

}
