using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject aligator;
    public GameObject Python;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(aligator,Vector3.zero,Quaternion.identity);
        }
    }
    public void spawnAligator()
    {
        Instantiate(aligator, Vector3.zero, Quaternion.identity);

    }public void spawnPython()
    {
        Instantiate(Python, Vector3.zero, Quaternion.identity);

    }
}
