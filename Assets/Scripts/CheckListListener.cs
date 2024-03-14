using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListListener : MonoBehaviour
{
    public Toggle CatToggle = null;
    public Toggle CrocToggle = null;
    public Toggle BassToggle = null;
    public Toggle rabbitToggle = null;
    public Toggle ToadToggle = null;
    public Toggle PythonToggle = null;
    public Toggle MangrooveToggle = null;
    public Toggle LitterToggle = null;
    public Toggle OilToggle = null;
    void checkObjects()
    {
        if(Checklist.cat)
        {
            CatToggle.isOn = true;
        }
        if(Checklist.Croc)
        {
            CrocToggle.isOn = true;
        }
        if(Checklist.bass)
        {
            BassToggle.isOn = true;
        }
        if(Checklist.Rabbit)
        {
            rabbitToggle.isOn = true;
        }
        if(Checklist.toad)
        {
            ToadToggle.isOn = true;
        }
        if(Checklist.python)
        {
            PythonToggle.isOn = true;
        }
        if(Checklist.mangroove)
        {
            MangrooveToggle.isOn = true;
        }
        if(Checklist.litter)
        {
            LitterToggle.isOn = true;
        }
        if(Checklist.oil)
        {
            Debug.Log("Oil is true");
            OilToggle.isOn = true;
        }


    }
    private void FixedUpdate() {
        checkObjects();
    }
}
