using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimatiions : MonoBehaviour
{
    XRBaseController controller;
    [Tooltip("The hand model prefab is the default state.")]
    public GameObject hand;
    [Tooltip("The hand model prefab is the grabbing state.")]
    public GameObject hand2;
    [Tooltip("The hand model prefab is the pointing state.")]
    public GameObject hand3;

    void Start()
    {
        controller = GetComponent<XRBaseController>();
    }
    
    public void Hand1()
    {
        controller.modelPrefab = hand.transform;
        //when the hand is doing nothing at all.

    }
    public void Hand2()
    {
        controller.modelPrefab = hand2.transform;
        //when the hand is grabbing something

    }
    public void Hand3()
    {
        controller.modelPrefab = hand3.transform;
        //when the hand is pointing at something

    }

}
