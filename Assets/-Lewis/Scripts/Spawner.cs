using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject aligator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(aligator,Vector3.zero,Quaternion.identity);
        }
    }
    void spawnAligator()
    {
        Instantiate(aligator, Vector3.zero, Quaternion.identity);

    }
}
