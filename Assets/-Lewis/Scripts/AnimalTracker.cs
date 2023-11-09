using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTracker : MonoBehaviour
{
    public static int fishCount;
    public static int AligatorCount;
    public static int  FrogCount;
    public static int PythonCount;
    public static void addAnimal(GameObject AnimalObject)
    {
        if (AnimalObject.tag == "Fish")
        {

            fishCount ++ ;
        }
        else if (AnimalObject.tag == "Aligator")
        {
            AligatorCount++;

        }
        else if (AnimalObject.tag == "Frog")
        {
            FrogCount++;

        }
        else if (AnimalObject.tag == "Python")
        {
            PythonCount++;

        }
    }
}
