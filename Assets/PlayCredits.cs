using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayCredits : MonoBehaviour
{
    public Image CanvasBase;
    IEnumerator waittodisplay()
    {
        yield return new WaitForSeconds(5);


        // Code to execute after the alpha lerp is complete
    }
}
