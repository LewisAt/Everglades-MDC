using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnimalCount : MonoBehaviour
{
    public static int fishCount = 0;
    public static int AligatorCount = 0;
    public static int FrogCount = 0;
    public static int PythonCount = 0;
    public void Awake()
    {
        
    }
    public static void RemoveFromCount(string animalTagName)
    {
        if(animalTagName == "Fish")
        {
            fishCount --;
        }
        else if (animalTagName == "Aligator")
        {
            AligatorCount--;
        }
        else if (animalTagName == "Frog")
        {
            FrogCount--;
        }
        else if (animalTagName == "Python")
        {
            PythonCount--;
        }
    }
    public static void addtoPopulationCount(string animalTagName)
    {
        if (animalTagName == "Fish")
        {
            fishCount ++;
        }
        else if (animalTagName == "Aligator")
        {
            AligatorCount++;
        }
        else if (animalTagName == "Frog")
        {
            FrogCount++;
        }
        else if (animalTagName == "Python")
        {
            PythonCount++;
        }
    }

}
