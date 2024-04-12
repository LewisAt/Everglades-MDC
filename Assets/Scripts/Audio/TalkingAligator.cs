using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingAligator : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private GameObject PivotPoint;
    void FixedUpdate()
    {
        float[] dBLevel = new float[2];
        audioSource.GetOutputData(dBLevel, 0);
        float angle = Mathf.Abs(dBLevel[0] + dBLevel[1]);

        Debug.Log(angle);
    }
}
