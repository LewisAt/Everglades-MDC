using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrackerAdder : MonoBehaviour
{
    private void Awake()
    {
        AnimalTracker.addAnimal(this.gameObject);
    }
}
