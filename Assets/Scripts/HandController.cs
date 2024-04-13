using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{

    private MeshFilter meshFilter;
    public Mesh HandOpen;
    bool pointing = false;
    public Mesh HandPoint;
    public Mesh HandGrab;
    public InputActionReference Action;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = transform.GetChild(0).GetComponent<MeshFilter>();
    }
    void Update()
    {
        float valueGripStrength = Action.action.ReadValue<float>();
        HandStateEnabler(valueGripStrength);

    }
    void HandStateEnabler(float value)
    {
        if (pointing)
        {
            return;
        }
        if (value < 0.5)
        {
            meshFilter.mesh = HandOpen;
            //Debug.Log("isOpening");
        }
        else
        {
            meshFilter.mesh = HandGrab;
        }

    }
    public void onUIHover()
    {
        pointing = true;
        meshFilter.mesh = HandPoint;
    }
    public void onUIExit()
    {
        pointing = false;
        meshFilter.mesh = HandOpen;
    }

    // Update is called once per frame

}
    