using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimatiions : MonoBehaviour
{
    XRBaseController controller;
    private GameObject CurrentHand;
    [Tooltip("The hand model prefab is the default state.")]
    public Mesh hand;
    [Tooltip("The hand model prefab is the grabbing state.")]
    public Mesh hand2;
    [Tooltip("The hand model prefab is the pointing state.")]
    public Mesh hand3;

    void Start()
    {
        controller = GetComponent<XRBaseController>();
        CurrentHand = controller.modelPrefab.GetChild(0).gameObject;
    }
    
    public void Hand1()
    {
        CurrentHand.GetComponent<MeshFilter>().sharedMesh = hand;
        
        //when the hand is doing nothing at all.

    }
    public void Hand2()
    {
        CurrentHand.GetComponent<MeshFilter>().sharedMesh = hand2;


        //when the hand is grabbing something

    }
    public void Hand3()
    {
        CurrentHand.GetComponent<MeshFilter>().sharedMesh = hand3;
        //when the hand is pointing at something

    }

}
