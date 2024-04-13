using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCredits : MonoBehaviour
{
    public Image CanvasBase;

    void Start()
    {
        StartCoroutine(waittodisplay());
    }
    IEnumerator waittodisplay()
    {
        yield return new WaitForSeconds(5);
        float duration = 1f; // Duration of the lerp in seconds
        float elapsedTime = 0f; // Elapsed time since the lerp started

        Color startColor = CanvasBase.color; // Starting color of the image
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target color with alpha set to 1

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Calculate the interpolation parameter
            CanvasBase.color = Color.Lerp(startColor, targetColor, t); // Lerp the color

            elapsedTime += Time.deltaTime; // Update the elapsed time
            yield return null; // Wait for the next frame
        }

        CanvasBase.color = targetColor; // Ensure the final color is set to the target color

        // Code to execute after the alpha lerp is complete
    }
}
