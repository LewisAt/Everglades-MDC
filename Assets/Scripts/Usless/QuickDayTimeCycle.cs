using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDayTimeCycle : MonoBehaviour
{
    public GameObject sun;
    public void timeDay()
    {
        sun.transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
    }
    public void timeNight()
    {
        sun.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
    }
}
