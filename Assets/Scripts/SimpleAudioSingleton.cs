using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudioSingleton : MonoBehaviour
{
    public static SimpleAudioSingleton instance;
    void Start()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
