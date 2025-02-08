using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInfoPC : MonoBehaviour
{
    public GameObject infoPanel; // Assign the info UI panel in Inspector
    private bool isInteracting = false;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false); // Ensure panel is hidden at start
    }

    void OnMouseDown() // When player clicks the animal
    {
        if (!isInteracting)
        {
            OpenInfoPanel();
        }
    }

    public void OpenInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            isInteracting = true;
        }
    }

    public void CloseInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
            isInteracting = false;
        }
    }
}
