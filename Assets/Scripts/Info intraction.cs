using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infointraction : MonoBehaviour
{
    [TextArea(15, 20)]
    public string infoTodisplay;
    public Text TextBoxToReveal;
    public GameObject CanvasBase;

    private void Awake()
    {
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
    private void FixedUpdate()
    {
        if (CanvasBase.activeSelf)
        {
            RotateTowards();
        }
    }
    void RotateTowards()
    {
        Vector3 Help = Vector3.RotateTowards(transform.position,Camera.main.transform.position,1f,0f);
        this.transform.rotation = Quaternion.LookRotation(Help);
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
